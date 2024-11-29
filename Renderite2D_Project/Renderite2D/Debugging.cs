using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderite2D_Project.Renderite2D
{
    public static class Debugging
    {
        public static void Log(object message)
        {
            try
            {
                Console.WriteLine(message.ToString());
            }
            catch { }
        }

        public static void Warning(object message)
        {
            try
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message.ToString());
                Console.ForegroundColor = c;
            } catch { }
        }

        public static void Error(object message)
        {
            try
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message.ToString());
                Console.ForegroundColor = c;
            } catch { }
        }

        public static void Clear()
        {
            try 
            {
                Console.Clear();
            } catch { }
        }
    }
}
