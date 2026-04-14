using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EmployeePayrollSystem
{
    public static class EmployeeManager
    {
        private static List<Employee> employees = new List<Employee>();
        private static List<Attendance> attendanceRecords = new List<Attendance>();
        private static List<Leave> leaveRequests = new List<Leave>();
        private static List<SalaryHistory> salaryHistories = new List<SalaryHistory>();
        private static int nextLeaveId = 1;

        // Load all data
        public static void LoadData()
        {
            employees = DataStorage.LoadEmployees();
            attendanceRecords = DataStorage.LoadAttendance();
            leaveRequests = DataStorage.LoadLeaves();
            salaryHistories = DataStorage.LoadSalaryHistory();
            if (leaveRequests.Any())
                nextLeaveId = leaveRequests.Max(l => l.LeaveId) + 1;
        }

        // Save all data
        public static void SaveAllData()
        {
            DataStorage.SaveEmployees(employees);
            DataStorage.SaveAttendance(attendanceRecords);
            DataStorage.SaveLeaves(leaveRequests);
            DataStorage.SaveSalaryHistory(salaryHistories);
        }

        // 1. Add Employee
        public static void AddEmployee()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Add New Employee ---");
            Console.ResetColor();
            Employee emp = new Employee();

            while (true)
            {
                Console.Write("Employee ID: ");
                if (int.TryParse(Console.ReadLine(), out int id) && !employees.Any(e => e.Id == id))
                {
                    emp.Id = id;
                    break;
                }
                Console.WriteLine("Invalid or duplicate ID.");
            }

            Console.Write("Name: "); emp.Name = Console.ReadLine();
            Console.Write("Designation: "); emp.Designation = Console.ReadLine();

            while (true)
            {
                Console.Write("Basic Salary: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal sal) && sal > 0)
                {
                    emp.BasicSalary = sal;
                    break;
                }
                Console.WriteLine("Invalid salary.");
            }

            while (true)
            {
                Console.Write("Join Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date) && date <= DateTime.Now)
                {
                    emp.JoinDate = date;
                    break;
                }
                Console.WriteLine("Invalid date.");
            }

            Console.Write("Overtime Hours: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal ot))
                emp.OvertimeHours = ot;
            else
                emp.OvertimeHours = 0;

            employees.Add(emp);
            SaveAllData();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ Employee added!");
            Console.ResetColor();
            Console.ReadKey();
        }

        // 2. View All Employees
        public static void ViewAllEmployees()
        {
            Console.Clear();
            if (employees.Count == 0)
                Console.WriteLine("No employees.");
            else
            {
                Console.WriteLine($"{"ID",-5} {"Name",-15} {"Designation",-15} {"Basic",-10} {"Net Salary",-12} {"Exp",-5}");
                Console.WriteLine(new string('-', 65));
                foreach (var e in employees)
                    Console.WriteLine($"{e.Id,-5} {e.Name,-15} {e.Designation,-15} {e.BasicSalary,-10:C} {e.NetSalary,-12:C} {e.ExperienceYears}y");
            }
            Console.ReadKey();
        }

        // 3. Search Employee
        public static void SearchEmployee()
        {
            Console.Clear();
            Console.Write("Search by ID or Name: ");
            string query = Console.ReadLine();
            var results = employees.Where(e => e.Id.ToString() == query || e.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            if (results.Count == 0)
                Console.WriteLine("Not found.");
            else
                foreach (var e in results)
                    Console.WriteLine($"ID: {e.Id} | Name: {e.Name} | Net Salary: {e.NetSalary:C}");
            Console.ReadKey();
        }

        // 4. Salary Slip
        public static void GenerateSalarySlip()
        {
            Console.Clear();
            Console.Write("Enter Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                Console.ReadKey();
                return;
            }
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                Console.WriteLine("Not found.");
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================= SALARY SLIP =================");
                Console.ResetColor();
                Console.WriteLine($"ID: {emp.Id} | Name: {emp.Name} | Designation: {emp.Designation}");
                Console.WriteLine($"Join Date: {emp.JoinDate:yyyy-MM-dd} (Exp: {emp.ExperienceYears} yrs)");
                Console.WriteLine($"Basic: {emp.BasicSalary:C} | Overtime: {emp.OvertimePay:C}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Tax: -{emp.Tax:C} | Medical: -{emp.Medical:C}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"NET SALARY: {emp.NetSalary:C}");
                Console.ResetColor();
                Console.WriteLine("================================================");
            }
            Console.ReadKey();
        }

        // 5. Update Employee
        public static void UpdateEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID."); Console.ReadKey(); return;
            }
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) { Console.WriteLine("Not found."); Console.ReadKey(); return; }
            Console.WriteLine($"Updating: {emp.Name}");
            Console.Write("New Name (blank to keep): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName)) emp.Name = newName;
            Console.Write("New Designation (blank to keep): ");
            string newDesig = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDesig)) emp.Designation = newDesig;
            Console.Write("New Basic Salary (0 to skip): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newSal) && newSal > 0)
                emp.BasicSalary = newSal;
            SaveAllData();
            Console.WriteLine("✓ Employee updated!");
            Console.ReadKey();
        }

        // 6. Delete Employee
        public static void DeleteEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID."); Console.ReadKey(); return;
            }
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) Console.WriteLine("Not found.");
            else
            {
                employees.Remove(emp);
                SaveAllData();
                Console.WriteLine($"✓ {emp.Name} deleted.");
            }
            Console.ReadKey();
        }

        // 7. Sort Employees
        public static void SortEmployees()
        {
            Console.Clear();
            Console.WriteLine("Sort by:\n1. Name (A-Z)\n2. Net Salary (High-Low)\n3. Experience (Years)\nChoice: ");
            string choice = Console.ReadLine();
            IEnumerable<Employee> sorted = employees;
            switch (choice)
            {
                case "1": sorted = employees.OrderBy(e => e.Name); break;
                case "2": sorted = employees.OrderByDescending(e => e.NetSalary); break;
                case "3": sorted = employees.OrderByDescending(e => e.ExperienceYears); break;
                default: Console.WriteLine("Invalid"); Console.ReadKey(); return;
            }
            Console.Clear();
            Console.WriteLine($"{"ID",-5} {"Name",-15} {"Designation",-15} {"Net Salary",-12} {"Exp",-5}");
            Console.WriteLine(new string('-', 55));
            foreach (var e in sorted)
                Console.WriteLine($"{e.Id,-5} {e.Name,-15} {e.Designation,-15} {e.NetSalary,-12:C} {e.ExperienceYears}y");
            Console.ReadKey();
        }

        // 8. Attendance
        public static void MarkAttendance()
        {
            Console.Clear();
            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || !employees.Any(e => e.Id == id))
            { Console.WriteLine("Invalid ID."); Console.ReadKey(); return; }
            Console.Write("Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Month (1-12): "); int month = int.Parse(Console.ReadLine());
            Console.Write("Days Present: "); int present = int.Parse(Console.ReadLine());
            var existing = attendanceRecords.FirstOrDefault(a => a.EmployeeId == id && a.Year == year && a.Month == month);
            if (existing != null) existing.DaysPresent = present;
            else attendanceRecords.Add(new Attendance { EmployeeId = id, Year = year, Month = month, DaysPresent = present });
            SaveAllData();
            Console.WriteLine("Attendance recorded.");
            Console.ReadKey();
        }

        public static void ViewAttendance()
        {
            Console.Clear();
            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            var records = attendanceRecords.Where(a => a.EmployeeId == id).OrderByDescending(a => a.Year).ThenByDescending(a => a.Month);
            Console.WriteLine($"Attendance for ID {id}:");
            foreach (var r in records)
                Console.WriteLine($"{r.Year}-{r.Month:D2}: {r.DaysPresent}/{r.TotalWorkingDays} days ({r.Percentage:F2}%)");
            Console.ReadKey();
        }

        // 9. Leave Management
        public static void ApplyLeave()
        {
            Console.Clear();
            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || !employees.Any(e => e.Id == id))
            { Console.WriteLine("Invalid ID."); Console.ReadKey(); return; }
            Console.Write("Start Date (yyyy-mm-dd): ");
            DateTime start = DateTime.Parse(Console.ReadLine());
            Console.Write("End Date (yyyy-mm-dd): ");
            DateTime end = DateTime.Parse(Console.ReadLine());
            Console.Write("Reason: ");
            string reason = Console.ReadLine();
            leaveRequests.Add(new Leave
            {
                LeaveId = nextLeaveId++,
                EmployeeId = id,
                StartDate = start,
                EndDate = end,
                Reason = reason,
                Status = "Pending"
            });
            SaveAllData();
            Console.WriteLine("Leave request submitted (Pending).");
            Console.ReadKey();
        }

        public static void ViewLeaveRequests()
        {
            Console.Clear();
            foreach (var l in leaveRequests)
            {
                var emp = employees.FirstOrDefault(e => e.Id == l.EmployeeId);
                Console.WriteLine($"Leave #{l.LeaveId} | Emp: {emp?.Name} ({l.EmployeeId}) | {l.StartDate:dd/MM} to {l.EndDate:dd/MM} | {l.Reason} | Status: {l.Status}");
            }
            Console.Write("\nEnter Leave ID to approve/reject (0 to exit): ");
            if (int.TryParse(Console.ReadLine(), out int lid) && lid != 0)
            {
                var leave = leaveRequests.FirstOrDefault(l => l.LeaveId == lid);
                if (leave != null)
                {
                    Console.Write("Approve (A) or Reject (R)? ");
                    string dec = Console.ReadLine().ToUpper();
                    if (dec == "A") leave.Status = "Approved";
                    else if (dec == "R") leave.Status = "Rejected";
                    SaveAllData();
                    Console.WriteLine("Updated.");
                }
            }
            Console.ReadKey();
        }

        // 10. Salary History
        public static void SaveCurrentMonthSalary()
        {
            var now = DateTime.Now;
            foreach (var emp in employees)
            {
                salaryHistories.Add(new SalaryHistory
                {
                    EmployeeId = emp.Id,
                    Year = now.Year,
                    Month = now.Month,
                    BasicSalary = emp.BasicSalary,
                    OvertimePay = emp.OvertimePay,
                    Deductions = emp.TotalDeductions,
                    NetSalary = emp.NetSalary,
                    GeneratedDate = now
                });
            }
            SaveAllData();
            Console.WriteLine("Salary history saved for this month.");
            Console.ReadKey();
        }

        public static void ViewSalaryHistory()
        {
            Console.Clear();
            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            var history = salaryHistories.Where(h => h.EmployeeId == id).OrderByDescending(h => h.Year).ThenByDescending(h => h.Month);
            Console.WriteLine($"Salary History for Employee ID {id}:");
            foreach (var h in history)
                Console.WriteLine($"{h.Year}-{h.Month:D2}: Net = {h.NetSalary:C} (Basic: {h.BasicSalary:C}, OT: {h.OvertimePay:C}, Ded: {h.Deductions:C})");
            Console.ReadKey();
        }

        // 11. Dashboard Statistics (Enhanced)
        public static void ShowStatistics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    📊 DASHBOARD STATISTICS 📊              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            // Employee Statistics
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n▶ EMPLOYEE STATISTICS");
            Console.ResetColor();
            Console.WriteLine($"   Total Employees        : {employees.Count}");
            if (employees.Count > 0)
            {
                Console.WriteLine($"   Total Monthly Expense  : {employees.Sum(e => e.NetSalary):C}");
                Console.WriteLine($"   Average Salary         : {employees.Average(e => e.NetSalary):C}");
                Console.WriteLine($"   Highest Salary         : {employees.Max(e => e.NetSalary):C}");
                Console.WriteLine($"   Lowest Salary          : {employees.Min(e => e.NetSalary):C}");
                var designationGroups = employees.GroupBy(e => e.Designation);
                Console.WriteLine("\n   📌 Designation-wise Count:");
                foreach (var group in designationGroups)
                    Console.WriteLine($"      - {group.Key}: {group.Count()} employee(s)");
            }
            else
                Console.WriteLine("   No employee data available.");

            // Attendance Statistics (Current Month)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n▶ ATTENDANCE STATISTICS (Current Month)");
            Console.ResetColor();
            int curYear = DateTime.Now.Year, curMonth = DateTime.Now.Month;
            var thisMonthAtt = attendanceRecords.Where(a => a.Year == curYear && a.Month == curMonth).ToList();
            if (thisMonthAtt.Any())
            {
                double avgAttendance = thisMonthAtt.Average(a => a.Percentage);
                Console.WriteLine($"   Average Attendance %  : {avgAttendance:F2}%");
                Console.WriteLine($"   Total Records         : {thisMonthAtt.Count}");
                var best = thisMonthAtt.OrderByDescending(a => a.Percentage).FirstOrDefault();
                var worst = thisMonthAtt.OrderBy(a => a.Percentage).FirstOrDefault();
                if (best != null)
                {
                    var empBest = employees.FirstOrDefault(e => e.Id == best.EmployeeId);
                    Console.WriteLine($"   Highest Attendance    : {empBest?.Name} (ID: {best.EmployeeId}) - {best.Percentage:F2}%");
                }
                if (worst != null)
                {
                    var empWorst = employees.FirstOrDefault(e => e.Id == worst.EmployeeId);
                    Console.WriteLine($"   Lowest Attendance     : {empWorst?.Name} (ID: {worst.EmployeeId}) - {worst.Percentage:F2}%");
                }
            }
            else
                Console.WriteLine("   No attendance records for current month.");

            // Leave Statistics
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n▶ LEAVE STATISTICS");
            Console.ResetColor();
            Console.WriteLine($"   Pending Leaves         : {leaveRequests.Count(l => l.Status == "Pending")}");
            Console.WriteLine($"   Approved Leaves        : {leaveRequests.Count(l => l.Status == "Approved")}");
            Console.WriteLine($"   Rejected Leaves        : {leaveRequests.Count(l => l.Status == "Rejected")}");
            Console.WriteLine($"   Total Leave Requests   : {leaveRequests.Count}");

            // Salary History Summary
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n▶ SALARY HISTORY SUMMARY");
            Console.ResetColor();
            if (salaryHistories.Any())
            {
                var lastMonth = salaryHistories.OrderByDescending(h => h.Year).ThenByDescending(h => h.Month).FirstOrDefault();
                Console.WriteLine($"   Last Salary Generation: {lastMonth?.GeneratedDate:yyyy-MM-dd}");
                Console.WriteLine($"   Total History Records : {salaryHistories.Count}");
                Console.WriteLine($"   Total Salary Paid (Hist): {salaryHistories.Sum(h => h.NetSalary):C}");
            }
            else
                Console.WriteLine("   No salary history available. Use 'Save Current Month Salary' first.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   End of Statistics Report                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to return to Dashboard...");
            Console.ReadKey();
        }

        // 12. Export Report
        public static void ExportReport()
        {
            string report = "EMPLOYEE PAYROLL REPORT\n";
            report += $"Generated: {DateTime.Now}\n";
            report += "----------------------------------------\n";
            report += $"{"ID",-5} {"Name",-15} {"Designation",-15} {"Net Salary",12}\n";
            foreach (var e in employees)
                report += $"{e.Id,-5} {e.Name,-15} {e.Designation,-15} {e.NetSalary,12:C}\n";
            report += $"----------------------------------------\n";
            report += $"Total Employees: {employees.Count}\n";
            report += $"Total Salary Expense: {employees.Sum(e => e.NetSalary):C}\n";
            File.WriteAllText("PayrollReport.txt", report);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ Report exported to PayrollReport.txt");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}