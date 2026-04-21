using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers; // ← ADD THIS
using System.Text;
using System.Text.Json;
using WorkSuiteAI.Application.AI.DTOs;
using WorkSuiteAI.Application.AI.Interfaces;

namespace WorkSuiteAI.Infrastructure.AI
{
    public class ClaudeClient : IClaudeClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ClaudeClient> _logger;
        private const string ClaudeApiUrl = "https://api.anthropic.com/v1/messages";

        public ClaudeClient(HttpClient httpClient, IConfiguration configuration, ILogger<ClaudeClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> SendPromptAsync(string prompt) // ← FIXED: Added 't'
        {
            _logger.LogInformation("Sending prompt to Claude API. Prompt length: {Length} characters", prompt.Length);

            var request = new ClaudeRequest
            {
                Model = "claude-sonnet-4-20250514",
                MaxTokens = 1000,
                Messages = new List<ClaudeMessage>
                {
                    new ()
                    {
                        Role = "user",
                        Content = prompt
                    }
                }
            };

            var response = await SendRequestAsync(request);

            var text = response.Content.FirstOrDefault()?.Text ?? string.Empty; // ← FIXED: Capital 'F'

            _logger.LogInformation("Claude API returned response. Length: {Length} characters", text.Length);

            return text;
        }

        public async Task<ClaudeResponse> SendRequestAsync(ClaudeRequest request)
        {
            _logger.LogInformation("Sending request to Claude API. Model: {Model}, MaxTokens: {MaxTokens}",
                request.Model, request.MaxTokens);

            try
            {
                var apiKey = _configuration["Claude:ApiKey"]; // ← FIXED: Added colon

                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    _logger.LogError("Claude API key not found in configuration");
                    throw new InvalidOperationException("Claude API key is not configured. Run: dotnet user-secrets set \"Claude:ApiKey\" \"your-key\"");
                }

                var jsonRequest = JsonSerializer.Serialize(request, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                _logger.LogDebug("Request JSON: {Json}", jsonRequest);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey); // ← FIXED: Lowercase
                _httpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");

                var httpResponse = await _httpClient.PostAsync(ClaudeApiUrl, content);

                var responseJson = await httpResponse.Content.ReadAsStringAsync();

                _logger.LogInformation("Response JSON: {Json}", responseJson);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Claude API returned error. StatusCode: {StatusCode}, Response: {Response}",
                        httpResponse.StatusCode, responseJson);

                    httpResponse.EnsureSuccessStatusCode();
                }

                var claudeResponse = JsonSerializer.Deserialize<ClaudeResponse>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (claudeResponse == null)
                {
                    _logger.LogError("Failed to deserialize Claude response");
                    throw new InvalidOperationException("Received null response from Claude API");
                }

                _logger.LogInformation("Claude API call successful. Input tokens: {InputTokens}, Output tokens: {OutputTokens}",
                    claudeResponse.Usage?.InputTokens ?? 0,
                    claudeResponse.Usage?.OutputTokens ?? 0);

                return claudeResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP error calling Claude API. StatusCode: {StatusCode}", ex.StatusCode);
                throw;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error deserializing Claude API response");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error calling Claude API");
                throw;
            }
        }
    }
}