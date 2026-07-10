using System.Text;
using ProfileManager.Interfaces;

namespace ProfileManager.Helpers
{
    public static class ConsoleHelper
    {
        private static readonly ConsoleColor[] MenuPalette =
        {
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Blue,
            ConsoleColor.Red,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkYellow,
        };

        public static string GetValidInput(string message, IValidator validator)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()!;

                if (validator.IsValid(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        // STRING INPUT
        public static string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine()!;
        }

        // INTEGER INPUT
        public static int GetIntInput(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        // DOUBLE INPUT
        public static double GetDoubleInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double result))
                    return result;
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public static void GetSpacing()
        {
            Console.WriteLine("==========================================");
        }

        public static void SectionTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"Topic: {title}");
            Console.WriteLine("------------------------------------------");
        }

        public static void MainTitle()
        {
            Console.Clear();
            string title = "PROFILE MANAGER";
            Console.WriteLine(new string('=', Console.WindowWidth));
            int spaces = (Console.WindowWidth - title.Length) / 2;
            Console.WriteLine(new string(' ', spaces) + title);
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        // Prints each menu option in a different color, cycling through the palette.
        public static void WriteMenu(IReadOnlyList<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                TrySetColor(MenuPalette[i % MenuPalette.Length]);
                Console.WriteLine(options[i]);
            }
            TryResetColor();
        }

        private static void TrySetColor(ConsoleColor color)
        {
            try { Console.ForegroundColor = color; } catch (IOException) { }
        }

        private static void TryResetColor()
        {
            try { Console.ResetColor(); } catch (IOException) { }
        }

        // Reads digits one at a time and auto-inserts the mask's literal characters
        // (e.g. mask "####-##-##" turns typed digits "19950101" into "1995-01-01" as you type).
        public static string GetValidMaskedInput(string message, IValidator validator, string mask)
        {
            while (true)
            {
                string input = GetMaskedInput(message, mask);

                if (validator.IsValid(input))
                    return input;

                Console.WriteLine("Invalid input. Try again.");
            }
        }

        public static string GetMaskedInput(string message, string mask)
        {
            Console.Write(message);

            int totalDigits = 0;
            foreach (char c in mask)
                if (c == '#') totalDigits++;

            var digits = new List<char>();
            string rendered = "";

            while (true)
            {
                string current = BuildMaskedString(mask, digits);
                Redraw(ref rendered, current);

                if (digits.Count == totalDigits)
                    break;

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (digits.Count > 0)
                        digits.RemoveAt(digits.Count - 1);
                }
                else if (char.IsDigit(key.KeyChar))
                {
                    digits.Add(key.KeyChar);
                }
            }

            Console.WriteLine();
            return BuildMaskedString(mask, digits);
        }

        private static string BuildMaskedString(string mask, List<char> digits)
        {
            var sb = new StringBuilder();
            int di = 0;

            foreach (char c in mask)
            {
                if (c == '#')
                {
                    if (di >= digits.Count)
                        break;
                    sb.Append(digits[di]);
                    di++;
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private static void Redraw(ref string previous, string current)
        {
            if (previous == current)
                return;

            Console.Write(new string('\b', previous.Length));
            Console.Write(current.PadRight(previous.Length));
            Console.Write(new string('\b', Math.Max(0, previous.Length - current.Length)));
            previous = current;
        }
    }
}
