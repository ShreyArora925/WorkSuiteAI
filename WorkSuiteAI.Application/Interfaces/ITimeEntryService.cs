using System;
using System.Collections.Generic;
using System.Text;
using WorkSuiteAI.Application.DTO;

namespace WorkSuiteAI.Application.Interfaces
{
    public interface ITimeEntryService
    {
        TimeEntryResponse ClockIn(CreateTimeEntryRequest request);
        TimeEntryResponse ClockOut(ClockOutRequest request);
        IEnumerable<TimeEntryResponse> GetByEmployeeId(int employeeId);
        IEnumerable<TimeEntryResponse> GetAll();
        TimeEntryResponse GetById(int id);
    }
}
