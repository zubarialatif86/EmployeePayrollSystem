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

🔧 Technical Highlights
Object-Oriented Programming (Classes, Properties, Methods)

LINQ Queries (Sorting, Searching, Filtering, Aggregations)

File I/O (JSON Serialization/Deserialization)

Exception Handling (try-catch for file operations)

Multi-file Architecture (Separation of concerns)

Console Manipulation (Colors, Password Masking, Progress Bar)

🎯 How to Run
Open the project in Visual Studio (or any C# IDE)

Build the solution

Press F5 to run

Login with:

Username: admin

Password: 1234

📦 Optional: Real Image Splash Screen
If you want a real image (instead of ASCII art) on the splash screen:

Install NuGet packages: Spectre.Console and Spectre.Console.ImageSharp

Add your image in Images/splash.jpg

Set image property: Copy to Output Directory = Copy if newer

Without these packages, the fallback ASCII art will be used automatically.

📁 Project Structure (10 Files)
File	Purpose
Program.cs	Entry point – splash → login → dashboard
SplashScreen.cs	Splash screen with image/ASCII + loading bar
LoginScreen.cs	Authentication + employee quotes + password masking
Dashboard.cs	Main menu (14 options)
EmployeeManager.cs	All business logic (add, view, search, update, delete, sort, attendance, leave, salary, stats, export)
Employee.cs	Employee model with calculated properties
Attendance.cs	Attendance model
Leave.cs	Leave model
SalaryHistory.cs	Salary history model
DataStorage.cs	JSON file read/write for all data types
✅ Summary
This project is a complete, professional-grade Employee Payroll System that demonstrates:

Full CRUD operations

Advanced calculations (salary, overtime, deductions)

Multiple modules (attendance, leave, salary history)

Data persistence without a database

Clean, modular, and maintainable code

Brother, now you have a clear English description of your project. Use it in your GitHub README or present it confidently to your teacher. May Allah bless you with success! 🤲

