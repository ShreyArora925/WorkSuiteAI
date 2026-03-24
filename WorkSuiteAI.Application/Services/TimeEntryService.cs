using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;
using WorkSuiteAI.Application.Interfaces;
using WorkSuiteAI.Domain.Entities;
using WorkSuiteAI.Infrastructure.Data;

namespace WorkSuiteAI.Application.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        public readonly IRepository<TimeEntry> _repository;
        public TimeEntryService(IRepository<TimeEntry> repository)
        {
            _repository = repository;
        }
        public TimeEntryResponse ClockIn(CreateTimeEntryRequest request)
        {
            var timeEntry = new TimeEntry
            {
                EmployeeID = request.EmployeeId,
                ClockIn = DateTime.UtcNow,
                CreateAt = DateTime.UtcNow
            };

            _repository.Add(timeEntry);

            return MapToResponse(timeEntry);
        }

        public TimeEntryResponse ClockOut(ClockOutRequest request)
        {
            var timeEntry = _repository.GetById(request.TimeEntryId);
            timeEntry.ClockOut = DateTime.UtcNow;
            timeEntry.HoursWorked = (decimal)(timeEntry.ClockOut - timeEntry.ClockIn).TotalHours;
            timeEntry.OverTime = timeEntry.HoursWorked > 8;

            _repository.Update(timeEntry);
            return MapToResponse(timeEntry);
        }

        public IEnumerable<TimeEntryResponse> GetByEmployeeId(int employeeId)
        {
            return _repository.GetAll()
               .Where(s => s.EmployeeID == employeeId)
               .Select(MapToResponse);

        }

        public IEnumerable<TimeEntryResponse> GetAll()
        {
            return _repository.GetAll().Select(MapToResponse);

        }

        public TimeEntryResponse GetById(int id)
        {
            var timeEntry = _repository.GetById(id);
            return MapToResponse(timeEntry);
        }

        private TimeEntryResponse MapToResponse(TimeEntry t)
        {
            return new TimeEntryResponse
            {
                Id = t.Id,
                EmployeeId = t.EmployeeID,
                ClockIn = t.ClockIn,
                ClockOut = t.ClockOut,
                HoursWorked = t.HoursWorked,
                IsOvertime = t.OverTime,
                CreatedAt = t.CreateAt
            };
        }
    }
}
