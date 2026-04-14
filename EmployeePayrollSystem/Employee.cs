using System;

namespace EmployeePayrollSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal OvertimeHours { get; set; }

        public decimal Tax => BasicSalary * 0.05m;
        public decimal Medical => BasicSalary * 0.02m;
        public decimal OvertimePay => OvertimeHours * (BasicSalary / (30 * 8)) * 1.5m;
        public decimal TotalDeductions => Tax + Medical;
        public decimal NetSalary => BasicSalary + OvertimePay - TotalDeductions;
        public int ExperienceYears => DateTime.Now.Year - JoinDate.Year;
    }
}