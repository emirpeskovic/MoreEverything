using System;
using System.Collections.Generic;

namespace MoreEverything.Console
{
    public static class ConsoleParse
    {
        private static Dictionary<string, bool> boolCommands = new Dictionary<string, bool>
        {
            { "true", true },
            { "yes", true },
            { "1", true },
            { "false", false },
            { "no", false },
            { "0", false }
        };

        public static int GetInt()
        {
            string input = "";
            int ret;
            while (!int.TryParse(input = System.Console.ReadLine(), out ret))
                System.Console.WriteLine("Could not parse input as integer, please check your input and try again.");
            return ret;
        }

        public static int[] GetIntArray(int length)
        {
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
                ConsoleEx.GetInput<int>($"Number {i + 1}: ");

            return arr;
        }

        public static bool GetBool()
        {
            bool ret;
            string input = ";";
            while (!boolCommands.TryGetValue(input = System.Console.ReadLine(), out ret))
                System.Console.WriteLine("Could not parse input as a boolean, please check your input and try again.");

            return ret;
        }
    }
}