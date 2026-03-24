using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface ITimeEntryService
    {
        Task <TimeEntryResponse> ClockIn(CreateTimeEntryRequest request);
        Task<TimeEntryResponse> ClockOut(ClockOutRequest request);
        Task<IEnumerable<TimeEntryResponse>> GetByEmployeeId(int employeeId);
        Task<IEnumerable<TimeEntryResponse>> GetAll();
        Task<TimeEntryResponse> GetById(int id);
    }
}
