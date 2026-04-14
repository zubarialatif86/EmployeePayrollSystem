 Employee Payroll Management System
This is a console-based application built with C# (.NET 6/8) that helps manage employee records, calculate salaries, track attendance, handle leave requests, maintain salary history, and generate reports — all with persistent JSON storage.

✅ Features Included in the Project
1. Authentication & Security
Login screen with username/password (default: admin/1234)

Password masking (asterisks while typing)

Random motivational quotes about employees displayed on login screen

2. Splash Screen
Professional welcome screen with ASCII art (or optional real image using Spectre.Console)

Loading animation (progress bar) before the login screen

3. Employee Management (CRUD)
➕ Add Employee – ID, Name, Designation, Basic Salary, Join Date, Overtime Hours

👁️ View All Employees – Display list with ID, Name, Designation, Basic Salary, Net Salary, Experience

🔍 Search Employee – By ID or Name (case-insensitive)

✏️ Update Employee – Modify name, designation, basic salary

🗑️ Delete Employee – Remove employee record

4. Salary Processing
Automatic salary calculation:

Net Salary = Basic Salary + Overtime Pay – (Tax + Medical)

Tax = 5% of Basic Salary

Medical = 2% of Basic Salary

Overtime Pay = Overtime Hours × (Hourly Rate × 1.5)

📄 Generate Salary Slip – Detailed breakdown (Basic, Overtime, Tax, Medical, Net Salary)

5. Sorting Employees
Sort by:

Name (A-Z)

Net Salary (Highest to Lowest)

Experience (Years, most experienced first)

6. Attendance Management
✅ Mark Attendance – Enter Year, Month, Days Present

📊 View Attendance – Show attendance percentage for each month

Total working days default = 30 days per month

7. Leave Management
📝 Apply for Leave – Submit start date, end date, reason (status = Pending)

👨‍💼 Approve / Reject Leave – View all leave requests, then approve or reject by Leave ID

8. Salary History
💾 Save Current Month Salary – Stores salary for all employees (Basic, Overtime, Deductions, Net Salary) with timestamp

📜 View Salary History – See past months' salaries for any employee

9. Dashboard Statistics
📊 Employee Summary – Total employees, total monthly expense, average/highest/lowest salary, designation-wise count

📈 Attendance Summary – Average attendance % for current month, best/worst attendance record

📋 Leave Summary – Pending, approved, rejected leaves count

🕒 Salary History Summary – Last generation date, total records, total salary paid

10. Reporting
📄 Export Report to Text File – Creates PayrollReport.txt with employee list and total expense

11. Data Persistence
All data stored in JSON files:

employees.json

attendance.json

leaves.json

salaryhistory.json

Data is automatically saved after every add, update, delete, attendance mark, leave request, etc.

Data persists after closing and reopening the application

12. Professional Console UI
Colored output (Cyan, Yellow, Green, Red)

ASCII borders and boxes for menus

Clean, user-friendly navigation

Input validation and error handling


