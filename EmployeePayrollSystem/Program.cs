using System;

namespace EmployeePayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Employee Payroll System";

            // Step 1: Show Splash Screen (with real image or ASCII)
            SplashScreen.Show();

            // Step 2: Load Data
            EmployeeManager.LoadData();

            // Step 3: Login Loop
            bool loggedIn = false;
            while (!loggedIn)
            {
                loggedIn = LoginScreen.Show();
            }

            // Step 4: Dashboard
            Dashboard.Show();

            // Step 5: Save & Exit
            EmployeeManager.SaveAllData();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThank you for using Employee Payroll System. Goodbye!");
            Console.ResetColor();
        }
    }
}