using System;

namespace EmployeePayrollSystem
{
    public class Attendance
    {
        public int EmployeeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int DaysPresent { get; set; }
        public int TotalWorkingDays { get; set; } = 30;

        public double Percentage => (double)DaysPresent / TotalWorkingDays * 100;
    }
}