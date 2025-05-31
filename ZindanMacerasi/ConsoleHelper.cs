using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public static class ConsoleHelper
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColored(string text, ConsoleColor color)

        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();

        }
    }
}
