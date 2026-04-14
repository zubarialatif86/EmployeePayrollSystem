using System;
using System.Threading;
using Spectre.Console;
using System.IO;

namespace EmployeePayrollSystem
{
    public static class SplashScreen
    {
        public static void Show()
        {
            Console.Clear();

            try
            {
                // Image ka path (folder ka naam "Images" hai)
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "splash1.png");
                // Agar aapki image ka naam "logo.png" hai to "splash.jpg" ki jagah "logo.png" likh do

                // Check if image exists
                if (File.Exists(imagePath))
                {
                    // Image load karo
                    var canvasImage = new CanvasImage(imagePath);

                    // Width set karo (console ke hisaab se adjust karo)
                    canvasImage.MaxWidth = 50; // 70 characters width

                    // Image render karo
                    AnsiConsole.Write(canvasImage);
                    AnsiConsole.WriteLine();
                }
                else
                {
                    // Agar image nahi mili to fallback ASCII art show karo
                    ShowFallbackSplash();
                }
            }
            catch (Exception ex)
            {
                // Agar koi error aata hai to fallback show karo
                ShowFallbackSplash();
            }

            // Professional Loading Bar
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t\t Initializing Payroll System");
            Console.Write("\t\t ");

            for (int i = 0; i < 15; i++)
            {
                Console.Write("█");
                Thread.Sleep(80);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\t ✓ System Ready Successfully!");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        // Fallback ASCII art agar image load na ho
        private static void ShowFallbackSplash()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] logo = {
                "╔══════════════════════════════════════════════════════════════════════╗",
                "║                                                                      ║",
                "║     ███████╗███╗   ███╗██████╗ ██╗      ██████╗ ██╗   ██╗           ║",
                "║     ██╔════╝████╗ ████║██╔══██╗██║     ██╔═══██╗╚██╗ ██╔╝           ║",
                "║     █████╗  ██╔████╔██║██████╔╝██║     ██║   ██║ ╚████╔╝            ║",
                "║     ██╔══╝  ██║╚██╔╝██║██╔═══╝ ██║     ██║   ██║  ╚██╔╝             ║",
                "║     ███████╗██║ ╚═╝ ██║██║     ███████╗╚██████╔╝   ██║              ║",
                "║     ╚══════╝╚═╝     ╚═╝╚═╝     ╚══════╝ ╚═════╝    ╚═╝              ║",
                "║                                                                      ║",
                "║              ██████╗  █████╗ ██╗   ██╗██████╗  ██████╗ ██╗         ║",
                "║              ██╔══██╗██╔══██╗╚██╗ ██╔╝██╔══██╗██╔═══██╗██║         ║",
                "║              ██████╔╝███████║ ╚████╔╝ ██████╔╝██║   ██║██║         ║",
                "║              ██╔═══╝ ██╔══██║  ╚██╔╝  ██╔══██╗██║   ██║██║         ║",
                "║              ██║     ██║  ██║   ██║   ██║  ██║╚██████╔╝███████╗    ║",
                "║              ╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝    ║",
                "║                                                                      ║",
                "║                 ┌─────────────────────────────────┐                  ║",
                "║                 │    ENTERPRISE PAYROLL SYSTEM    │                  ║",
                "║                 │       Version 3.0 | 2025        │                  ║",
                "║                 └─────────────────────────────────┘                  ║",
                "║                                                                      ║",
                "║              ◇◇◇ EMPOWERING BUSINESSES WORLDWIDE ◇◇◇              ║",
                "║                                                                      ║",
                "╚══════════════════════════════════════════════════════════════════════╝"
            };

            foreach (string line in logo)
            {
                Console.WriteLine(line);
                Thread.Sleep(8);
            }
            Console.ResetColor();
        }
    }
}