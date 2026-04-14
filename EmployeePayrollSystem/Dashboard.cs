using System;

namespace EmployeePayrollSystem
{
    public static class Dashboard
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════╗");
                Console.WriteLine("║              EMPLOYEE PAYROLL DASHBOARD            ║");
                Console.WriteLine("╠════════════════════════════════════════════════════╣");
                Console.ResetColor();
                Console.WriteLine("║ 1.  Add Employee                                  ║");
                Console.WriteLine("║ 2.  View All Employees                            ║");
                Console.WriteLine("║ 3.  Search Employee                               ║");
                Console.WriteLine("║ 4.  Generate Salary Slip                          ║");
                Console.WriteLine("║ 5.  Update Employee Details                       ║");
                Console.WriteLine("║ 6.  Delete Employee                               ║");
                Console.WriteLine("║ 7.  Sort Employees                                ║");
                Console.WriteLine("║ 8.  Mark/View Monthly Attendance                  ║");
                Console.WriteLine("║ 9.  Apply Leave / View/Manage Leaves              ║");
                Console.WriteLine("║ 10. Save Current Month Salary History             ║");
                Console.WriteLine("║ 11. View Salary History of Employee               ║");
                Console.WriteLine("║ 12. Dashboard Statistics                          ║");
                Console.WriteLine("║ 13. Export Report to Text File                    ║");
                Console.WriteLine("║ 14. Logout & Exit                                 ║");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": EmployeeManager.AddEmployee(); break;
                    case "2": EmployeeManager.ViewAllEmployees(); break;
                    case "3": EmployeeManager.SearchEmployee(); break;
                    case "4": EmployeeManager.GenerateSalarySlip(); break;
                    case "5": EmployeeManager.UpdateEmployee(); break;
                    case "6": EmployeeManager.DeleteEmployee(); break;
                    case "7": EmployeeManager.SortEmployees(); break;
                    case "8":
                        Console.WriteLine("1. Mark Attendance  2. View Attendance");
                        string sub = Console.ReadLine();
                        if (sub == "1") EmployeeManager.MarkAttendance();
                        else EmployeeManager.ViewAttendance();
                        break;
                    case "9":
                        Console.WriteLine("1. Apply Leave  2. View/Manage Leaves");
                        sub = Console.ReadLine();
                        if (sub == "1") EmployeeManager.ApplyLeave();
                        else EmployeeManager.ViewLeaveRequests();
                        break;
                    case "10": EmployeeManager.SaveCurrentMonthSalary(); break;
                    case "11": EmployeeManager.ViewSalaryHistory(); break;
                    case "12": EmployeeManager.ShowStatistics(); break;
                    case "13": EmployeeManager.ExportReport(); break;
                    case "14": return;
                    default: Console.WriteLine("Invalid!"); Console.ReadKey(); break;
                }
            }
        }
    }
}