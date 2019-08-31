using System;

namespace UserInterface
{
    public class UI
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetValueFromInput()
        {
            return Console.ReadLine();
        }

        public static bool WillContinue()
        {
            string answer;

            do
            {
                answer = Console.ReadLine().ToUpper();
            }
            while (answer != "Y" && answer != "YES" && answer != "N" && answer != "NO");

            return (answer == "Y" || answer == "YES");
        }

        public static void ResetConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
