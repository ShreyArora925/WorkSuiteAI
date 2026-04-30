# WorkSuiteAI

> Enterprise-grade HR & Workforce Management API built with .NET 10, Clean Architecture, and AI Integration.

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![C#](https://img.shields.io/badge/C%23-12.0-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)
![React](https://img.shields.io/badge/React-18.0-blue)
![JWT](https://img.shields.io/badge/Auth-JWT-green)
![AI](https://img.shields.io/badge/AI-Claude%20API-orange)
![License](https://img.shields.io/badge/License-MIT-yellow)

---

## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
  - [AI Integration Setup](#ai-integration-setup)
- [API Endpoints](#api-endpoints)
- [Running Tests](#running-tests)
- [Design Patterns](#design-patterns)
- [Author](#author)

---

## Overview

WorkSuiteAI is a production-grade enterprise full-stack application demonstrating modern .NET backend development with React frontend and AI-powered workforce insights. Built to showcase Clean Architecture, CQRS pattern, JWT authentication, and intelligent job matching capabilities.

The platform manages employee records, tracks work hours, handles payroll calculations, and integrates AI to provide intelligent job matching, resume analysis, and automated cover letter generation for job seekers.

---

## Architecture

WorkSuiteAI follows **Clean Architecture** with strict separation of concerns:

```
┌─────────────────────────────────────────────────────┐
│          React Frontend (Port 3000)                 │  ← UI Components, Pages, Services
│                                                     │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────┐│
│  │ Login Page   │  │ Job Agent    │  │ Employee ││
│  │              │  │ Search UI    │  │ Dashboard││
│  └──────────────┘  └──────────────┘  └──────────┘│
└─────────────────────────────────────────────────────┘
                          ↓ HTTP/JWT
┌─────────────────────────────────────────────────────┐
│        .NET 10 Web API (Port 5286)                  │
│                                                     │
│  ┌────────────────────────────────────────────────┐│
│  │         Controllers Layer                      ││  ← Auth, Employees, TimeEntries, JobAgent
│  └────────────────────────────────────────────────┘│
│  ┌────────────────────────────────────────────────┐│
│  │     Application Layer (CQRS/MediatR)          ││  ← Commands, Queries, Handlers, Services
│  │                                                ││
│  │  ┌──────────────┐  ┌──────────────────────┐  ││
│  │  │ Employee     │  │ AI Integration       │  ││
│  │  │ Service      │  │ JobAgentService      │  ││
│  │  └──────────────┘  └──────────────────────┘  ││
│  └────────────────────────────────────────────────┘│
│  ┌────────────────────────────────────────────────┐│
│  │         Domain Layer                           ││  ← Entities, Interfaces (Core)
│  └────────────────────────────────────────────────┘│
│  ┌────────────────────────────────────────────────┐│
│  │     Infrastructure Layer                       ││  ← Repository, DbContext, Migrations
│  └────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────┐
│              SQL Server Database                    │  ← Employees, TimeEntries, Users
└─────────────────────────────────────────────────────┘

                          ↓
┌─────────────────────────────────────────────────────┐
│         External AI Service (Claude API)            │  ← Job Matching, Cover Letter Generation
└─────────────────────────────────────────────────────┘
```

**Dependency Rule:** Dependencies only point inward. Domain knows nothing about outer layers.

---

## Tech Stack

| Category | Technology |
|----------|-----------|
| **Backend Framework** | .NET 10, ASP.NET Core |
| **Language** | C# 12 |
| **ORM** | Entity Framework Core 10 |
| **Database** | SQL Server |
| **Authentication** | JWT Bearer Tokens |
| **Messaging** | MediatR (CQRS) |
| **Validation** | FluentValidation |
| **Testing** | xUnit + NSubstitute |
| **Password Hashing** | BCrypt.Net |
| **Documentation** | Swagger / OpenAPI |
| **Frontend Framework** | React 18 |
| **Frontend Language** | JavaScript (ES6+) |
| **HTTP Client** | Fetch API |
| **Frontend Styling** | Inline CSS (component-based) |
| **AI Integration** | Claude API (Anthropic) |
| **AI Capabilities** | Resume Analysis, Job Matching, Cover Letter Generation |

---

## Features

### ✅ Backend (Implemented)
- **Employee Management** — Full CRUD with async operations
- **Time Tracking** — Clock In/Out with automatic hours calculation and overtime detection
- **JWT Authentication** — Secure Register/Login with BCrypt password hashing
- **CQRS Pattern** — MediatR handlers for GetAll, GetById, CreateEmployee
- **Clean Architecture** — 4-layer separation with dependency inversion
- **Generic Repository** — Reusable async data access pattern
- **FluentValidation** — Request validation with meaningful error messages
- **Global Exception Handling** — Middleware for consistent error responses
- **Unit Tests** — xUnit tests with NSubstitute mocking
- **Swagger UI** — Interactive API documentation

### ✅ Frontend (Implemented)
- **Login Page** — JWT authentication with token storage
- **Job Agent Search UI** — Multi-criteria job search interface
  - Location-based filtering
  - Keyword search
  - Salary range filtering
  - Maximum results control
- **Job Results Display** — Color-coded match scoring
  - Match score badges (Green ≥80%, Yellow ≥60%, Red <60%)
  - Job cards with company, location, salary details
  - Match reasoning explanations
- **Cover Letter Modal** — Interactive cover letter viewer
  - Copy to clipboard functionality
  - Download as .txt file
  - Company-specific naming
- **Protected Routes** — Login-based navigation with localStorage token management
- **Logout Functionality** — Secure session termination

### ✅ AI Integration (Implemented)
- **Job Agent Service** — Intelligent job matching pipeline
  - Multi-step orchestration with 3 AI tools
  - Sequential processing workflow
- **Job Search Tool** — Simulated job market search
- **Resume Analyzer** — AI-powered job-resume matching
  - Scoring algorithm (0-100)
  - Match reasoning generation
- **Cover Letter Generator** — Personalized cover letters
  - Job-specific customization
  - Company-tailored content
- **API Endpoints** — `/api/jobagent/search` with comprehensive request/response handling

### 🚧 In Progress
- **React Dashboard** — Employee and time entry management UI
- **AI Enhancements** — Real job board API integration
- **Testing Coverage** — Frontend component tests
- **Azure Deployment** — Cloud hosting setup
- **GitHub Actions CI/CD** — Automated deployment pipeline

---

## Project Structure

```
WorkSuiteAI/
│
├── WorkSuiteAI.Api/                          # Backend API
│   ├── Controllers/
│   │   ├── EmployeesController.cs
│   │   ├── TimeEntriesController.cs
│   │   ├── AuthController.cs
│   │   └── JobAgentController.cs            # AI job matching endpoint
│   ├── Middleware/
│   │   └── ExceptionMiddleware.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── WorkSuiteAI.Application/                  # Business Logic Layer
│   ├── Commands/
│   │   └── CreateEmployeeCommand.cs
│   ├── Queries/
│   │   ├── GetAllEmployeesQuery.cs
│   │   └── GetEmployeeByIdQuery.cs
│   ├── Handlers/
│   │   ├── GetAllEmployeesHandler.cs
│   │   ├── GetEmployeeByIdHandler.cs
│   │   └── CreateEmployeeHandler.cs
│   ├── Services/
│   │   ├── EmployeeService.cs
│   │   ├── TimeEntryService.cs
│   │   ├── AuthService.cs
│   │   └── AI/                               # AI Integration Services
│   │       ├── JobAgentService.cs           # Main orchestration service
│   │       ├── JobSearchTool.cs             # Job search simulation
│   │       ├── ResumeAnalyzer.cs            # AI-powered matching
│   │       └── CoverLetterGenerator.cs      # Personalized cover letters
│   ├── Interfaces/
│   │   ├── IEmployeeService.cs
│   │   ├── ITimeEntryService.cs
│   │   ├── IAuthService.cs
│   │   └── AI/
│   │       ├── IJobAgentService.cs
│   │       ├── IJobSearchTool.cs
│   │       ├── IResumeAnalyzer.cs
│   │       └── ICoverLetterGenerator.cs
│   ├── DTO/
│   │   ├── CreateEmployeeRequest.cs
│   │   ├── EmployeeResponse.cs
│   │   ├── CreateTimeEntryRequest.cs
│   │   ├── TimeEntryResponse.cs
│   │   ├── LoginRequest.cs
│   │   ├── RegisterRequest.cs
│   │   ├── AuthResponse.cs
│   │   └── AI/                               # AI DTOs
│   │       ├── JobAgentSearchRequest.cs
│   │       ├── JobAgentSearchResponse.cs
│   │       └── JobMatch.cs
│   └── Validators/
│       └── CreateEmployeeValidator.cs
│
├── WorkSuiteAI.Domain/                       # Core Domain
│   ├── Entities/
│   │   ├── Employee.cs
│   │   ├── TimeEntry.cs
│   │   └── User.cs
│   └── Interfaces/
│       └── IRepository.cs
│
├── WorkSuiteAI.Infrastructure/               # Data Access Layer
│   ├── Repositories/
│   │   └── Repository.cs
│   └── Data/
│       ├── AppDbContext.cs
│       └── Migrations/
│
├── WorkSuiteAI.Tests/                        # Unit Tests
│   └── EmployeeServiceTests.cs
│
├── worksuite-ui/                             # React Frontend
│   ├── public/
│   │   └── index.html
│   ├── src/
│   │   ├── components/                       # Reusable components
│   │   ├── pages/
│   │   │   ├── Login.jsx                    # Authentication page
│   │   │   └── JobAgent.jsx                 # Job search and results page
│   │   ├── services/
│   │   │   ├── authService.js               # Auth API calls
│   │   │   └── jobService.js                # Job Agent API calls
│   │   ├── App.jsx                          # Main app component
│   │   ├── App.css
│   │   └── index.js
│   ├── package.json
│   └── .env                                  # Frontend environment variables
│
├── .gitignore
└── README.md
```

---

## Getting Started

### Backend Setup

#### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code

#### Installation

**1. Clone the repository:**
```bash
git clone https://github.com/ShreyArora925/WorkSuiteAI.git
cd WorkSuiteAI
```

**2. Configure connection string in `WorkSuiteAI.Api/appsettings.json`:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\ProjectModels;Database=WorkSuiteAI;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "JwtSettings": {
    "SecretKey": "your-super-secret-key-minimum-32-characters",
    "Issuer": "WorkSuiteAI",
    "Audience": "WorkSuiteAI",
    "ExpiryHours": 1
  }
}
```

**3. Apply database migrations:**
```bash
cd WorkSuiteAI.Infrastructure
dotnet ef database update
```

**4. Run the API:**
```bash
cd ../WorkSuiteAI.Api
dotnet run
```

**5. Open Swagger UI:**
```
https://localhost:7284/swagger
```

---

### Frontend Setup

#### Prerequisites

- [Node.js](https://nodejs.org/) (v18+ recommended)
- npm or yarn package manager

#### Installation

**1. Navigate to frontend directory:**
```bash
cd worksuite-ui
```

**2. Install dependencies:**
```bash
npm install
```

**3. Create `.env` file in `worksuite-ui/` directory:**
```env
REACT_APP_API_URL=http://localhost:5286
```

**4. Start development server:**
```bash
npm start
```

**5. Open browser:**
```
http://localhost:3000
```

#### Default Test User

Use these credentials to test the application:

**Email:** `admin@worksuite.com`  
**Password:** `Admin123!`

*(Or register a new user via the Register endpoint)*

---

### AI Integration Setup

#### Prerequisites

- Claude API Key from [Anthropic Console](https://console.anthropic.com/)

#### Configuration

**1. Add Claude API key to `appsettings.json`:**
```json
{
  "ClaudeApi": {
    "ApiKey": "sk-ant-your-api-key-here",
    "Model": "claude-sonnet-4-20250514",
    "MaxTokens": 4000
  }
}
```

**2. Verify AI service registration in `Program.cs`:**
```csharp
// AI Services
builder.Services.AddScoped<IJobAgentService, JobAgentService>();
builder.Services.AddScoped<IJobSearchTool, JobSearchTool>();
builder.Services.AddScoped<IResumeAnalyzer, ResumeAnalyzer>();
builder.Services.AddScoped<ICoverLetterGenerator, CoverLetterGenerator>();
```

**3. Test AI endpoint:**

The AI integration is accessible via the Job Agent endpoint. Use the frontend Job Agent page or test directly via Swagger/Postman.

---

## API Endpoints

### Authentication
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| POST | `/api/auth/register` | Register new user | Public |
| POST | `/api/auth/login` | Login and get JWT token | Public |

### Employees
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/employees` | Get all employees | Required |
| GET | `/api/employees/{id}` | Get employee by ID | Required |
| POST | `/api/employees` | Create employee | Required |
| PUT | `/api/employees/{id}` | Update employee | Required |
| DELETE | `/api/employees/{id}` | Delete employee | Required |

### Time Entries
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| GET | `/api/timeentries` | Get all time entries | Required |
| GET | `/api/timeentries/{id}` | Get time entry by ID | Required |
| GET | `/api/timeentries/employee/{id}` | Get entries by employee | Required |
| POST | `/api/timeentries/clockin` | Clock in | Required |
| POST | `/api/timeentries/clockout` | Clock out | Required |

### AI Job Agent
| Method | Endpoint | Description | Auth |
|--------|----------|-------------|------|
| POST | `/api/jobagent/search` | AI-powered job matching with cover letters | Required |

---

### Example Requests

#### Register
```json
POST /api/auth/register
Content-Type: application/json

{
  "email": "admin@worksuite.com",
  "password": "Admin123!",
  "role": "Admin"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "email": "admin@worksuite.com",
  "role": "Admin",
  "expiry": "2026-04-28T10:00:00Z"
}
```

---

#### AI Job Agent Search

**Request:**
```json
POST /api/jobagent/search
Authorization: Bearer {token}
Content-Type: application/json

{
  "location": "Toronto, ON",
  "keywords": "C# ASP.NET Core",
  "salary": {
    "min": 80000,
    "max": 120000
  },
  "experienceLevel": "Mid-Senior",
  "maxResults": 5,
  "postedWithinDays": 30
}
```

**Response:**
```json
{
  "totalResults": 3,
  "searchCriteria": {
    "location": "Toronto, ON",
    "keywords": "C# ASP.NET Core",
    "salary": {
      "min": 80000,
      "max": 120000
    },
    "experienceLevel": "Mid-Senior",
    "maxResults": 5,
    "postedWithinDays": 30
  },
  "matches": [
    {
      "jobId": "job-001",
      "title": "Senior .NET Developer",
      "company": "TechCorp Inc.",
      "location": "Toronto, ON",
      "salary": "$95,000 - $115,000",
      "postedDate": "2026-04-20T00:00:00Z",
      "matchScore": 87,
      "matchReason": "Strong alignment with C# and ASP.NET Core requirements. Your Clean Architecture and CQRS experience matches their microservices focus. Salary range fits your expectations.",
      "coverLetter": "Dear Hiring Manager,\n\nI am writing to express my strong interest in the Senior .NET Developer position at TechCorp Inc...\n\n[Full personalized cover letter content]\n\nSincerely,\n[Your Name]"
    },
    {
      "jobId": "job-002",
      "title": "Full Stack .NET Engineer",
      "company": "StartupXYZ",
      "location": "Toronto, ON (Remote)",
      "salary": "$85,000 - $105,000",
      "postedDate": "2026-04-22T00:00:00Z",
      "matchScore": 78,
      "matchReason": "Good match for .NET Core backend skills. React experience is a plus. Remote flexibility available. Salary slightly below target max.",
      "coverLetter": "Dear Hiring Manager,\n\n[Personalized cover letter for StartupXYZ]..."
    }
  ]
}
```

**AI Processing Steps:**
1. **Job Search Tool** — Searches for jobs matching criteria
2. **Resume Analyzer** — Scores each job against your profile (0-100)
3. **Cover Letter Generator** — Creates personalized cover letters for matched jobs

---

#### Create Employee

```json
POST /api/employees
Authorization: Bearer {token}
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@worksuite.com",
  "department": "Engineering",
  "hourlyRate": 45.00
}
```

**Response:**
```json
{
  "id": 1,
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@worksuite.com",
  "department": "Engineering",
  "hourlyRate": 45.00,
  "createdAt": "2026-04-28T09:00:00Z"
}
```

---

#### Clock In

```json
POST /api/timeentries/clockin
Authorization: Bearer {token}
Content-Type: application/json

{
  "employeeId": 1
}
```

---

#### Clock Out

```json
POST /api/timeentries/clockout
Authorization: Bearer {token}
Content-Type: application/json

{
  "timeEntryId": 1
}
```

**Response:**
```json
{
  "id": 1,
  "employeeId": 1,
  "clockIn": "2026-04-28T09:00:00Z",
  "clockOut": "2026-04-28T17:30:00Z",
  "hoursWorked": 8.50,
  "isOvertime": false,
  "createdAt": "2026-04-28T09:00:00Z"
}
```

---

## Running Tests

```bash
cd WorkSuiteAI.Tests
dotnet test
```

**Current test coverage:**
- EmployeeService — CreateEmployee, GetAll, Repository interaction

---

## Design Patterns

### Clean Architecture
Each layer has a single responsibility and dependencies only point inward toward the Domain layer.

### CQRS with MediatR
Read and write operations are separated into Queries and Commands, each handled by dedicated Handler classes.

```csharp
// Query — reads data
public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>> { }

// Handler — processes the query
public class GetAllEmployeesHandler 
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
{
    public async Task<IEnumerable<EmployeeResponse>> Handle(
        GetAllEmployeesQuery request, CancellationToken cancellationToken)
    { ... }
}
```

### Repository Pattern
Generic repository abstracts data access, enabling easy testing and future database swaps.

```csharp
public interface IRepository<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
```

### Service Orchestration Pattern (AI Integration)
JobAgentService orchestrates multiple AI tools in a sequential pipeline:

```csharp
public async Task<JobAgentSearchResponse> SearchJobsAsync(JobAgentSearchRequest request)
{
    // Step 1: Search for jobs
    var jobs = await _jobSearchTool.SearchJobsAsync(request);
    
    // Step 2: Analyze each job for matching
    var analyzedJobs = new List<JobMatch>();
    foreach (var job in jobs)
    {
        var analysis = await _resumeAnalyzer.AnalyzeJobMatchAsync(job, userResume);
        
        // Step 3: Generate cover letter if good match
        if (analysis.MatchScore >= 70)
        {
            var coverLetter = await _coverLetterGenerator.GenerateAsync(job, userResume);
            analyzedJobs.Add(new JobMatch { Job = job, Analysis = analysis, CoverLetter = coverLetter });
        }
    }
    
    return new JobAgentSearchResponse { Matches = analyzedJobs };
}
```

### JWT Authentication Flow
```
1. Client → POST /api/auth/login
2. Server validates credentials against DB
3. Server generates signed JWT token
4. Client stores token in localStorage
5. Client sends token in Authorization header for protected routes
6. Server validates token signature on every protected request
```

### FluentValidation
Request validation separated from business logic with clear error messages.

```csharp
public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.HourlyRate).GreaterThanOrEqualTo(16.55m);
    }
}
```

### Global Exception Handling
Middleware catches all unhandled exceptions returning consistent clean responses.

```json
{
  "status": 404,
  "message": "Record with id 999 not found"
}
```

---

## Author

**Shrey Arora**
- 💼 [LinkedIn](https://www.linkedin.com/in/s-arora95/)
- 🐙 [GitHub](https://github.com/ShreyArora925)
- 📧 shreyarora925@gmail.com

---

## License

This project is licensed under the MIT License.

---

*Built as a portfolio project demonstrating enterprise .NET development practices including Clean Architecture, CQRS, JWT Authentication, React frontend integration, and AI-powered job matching with Claude API.*
