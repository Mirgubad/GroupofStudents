using System;
using static System.Console;

namespace GroupofStudents
{
    public static class Helpers
    {
       

        public static void PrintCol(string text, ConsoleColor color)
        {
            ForegroundColor = color;
           
            WriteLine(text, color);
            ResetColor();
        }


    }
}
