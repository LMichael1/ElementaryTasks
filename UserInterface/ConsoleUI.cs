using System;

namespace UserInterface
{
    public class ConsoleUI
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetValueFromInput(string messageToShow)
        {
            Console.WriteLine(messageToShow);

            return Console.ReadLine();
        }

        public static bool WillContinue(string messageToShow)
        {
            Console.WriteLine(messageToShow);

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
