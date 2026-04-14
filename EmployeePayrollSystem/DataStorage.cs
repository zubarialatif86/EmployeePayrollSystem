using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EmployeePayrollSystem
{
    public static class DataStorage
    {
        private static readonly string employeeFile = "employees.json";
        private static readonly string attendanceFile = "attendance.json";
        private static readonly string leaveFile = "leaves.json";
        private static readonly string salaryHistoryFile = "salaryhistory.json";

        // Employees
        public static void SaveEmployees(List<Employee> employees)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(employees, options);
                File.WriteAllText(employeeFile, json);
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        public static List<Employee> LoadEmployees()
        {
            try
            {
                if (File.Exists(employeeFile))
                {
                    string json = File.ReadAllText(employeeFile);
                    return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            return new List<Employee>();
        }

        // Attendance
        public static void SaveAttendance(List<Attendance> list)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(attendanceFile, json);
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        public static List<Attendance> LoadAttendance()
        {
            try
            {
                if (File.Exists(attendanceFile))
                {
                    string json = File.ReadAllText(attendanceFile);
                    return JsonSerializer.Deserialize<List<Attendance>>(json) ?? new List<Attendance>();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            return new List<Attendance>();
        }

        // Leaves
        public static void SaveLeaves(List<Leave> list)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(leaveFile, json);
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        public static List<Leave> LoadLeaves()
        {
            try
            {
                if (File.Exists(leaveFile))
                {
                    string json = File.ReadAllText(leaveFile);
                    return JsonSerializer.Deserialize<List<Leave>>(json) ?? new List<Leave>();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            return new List<Leave>();
        }

        // Salary History
        public static void SaveSalaryHistory(List<SalaryHistory> list)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(salaryHistoryFile, json);
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        public static List<SalaryHistory> LoadSalaryHistory()
        {
            try
            {
                if (File.Exists(salaryHistoryFile))
                {
                    string json = File.ReadAllText(salaryHistoryFile);
                    return JsonSerializer.Deserialize<List<SalaryHistory>>(json) ?? new List<SalaryHistory>();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            return new List<SalaryHistory>();
        }
    }
}