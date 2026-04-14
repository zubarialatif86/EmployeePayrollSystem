using System;
using System.Threading;

namespace EmployeePayrollSystem
{
    public static class LoginScreen
    {
        private const string Username = "admin";
        private const string Password = "1234";

        // Array of inspiring employee quotes
        private static readonly string[] quotes = {
            "“A company's culture is the foundation for its success. Happy employees = happy customers = happy shareholders.”",

            "“The way your employees feel is the way your customers will feel.” ",

            "“Success is not just about making money. It's about making a difference – for your employees, your customers, and your community.”"
        };

        public static bool Show()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                    🔐 SECURE LOGIN PORTAL 🔐               ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.ResetColor();

            // Display a random quote
            Random rand = new Random();
            string quote = quotes[rand.Next(quotes.Length)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n   💡 Employee Inspiration:\n   {quote}\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.ResetColor();
            Console.Write("\n   👤 Username: ");
            string user = Console.ReadLine();
            Console.Write("   🔒 Password: ");
            string pass = ReadPassword(); // Mask password input
            Console.WriteLine();

            if (user == Username && pass == Password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n   ✓ Login Successful! Welcome, Administrator.");
                Console.WriteLine("   Redirecting to Dashboard...");
                Console.ResetColor();
                Thread.Sleep(1500);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   ✗ Login Failed! Invalid username or password.");
                Console.WriteLine("   Please try again.");
                Console.ResetColor();
                Thread.Sleep(1500);
                return false;
            }
        }

        // Method to mask password input (show asterisks)
        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            return password;
        }
    }
}