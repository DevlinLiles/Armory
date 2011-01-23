using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armory.Facades
{
    public class ConsoleFacade : IConsoleFacade
    {
        public ConsoleColor BackgroundColor
        {
            get
            {
                return Console.BackgroundColor;
            }
            set
            {
                Console.BackgroundColor = value;
            }
        }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return Console.ForegroundColor;
            }
            set
            {
                Console.ForegroundColor = value;
            }
        }

        public string Title
        {
            get
            {
                return Console.Title;
            }
            set
            {
                Console.Title = value;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
        
        public int Read()
        {
            return Console.Read();
        }
        
        public ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }
        
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        
        public void ResetColor()
        {
            Console.ResetColor();
        }
        
        public void Write<T>(T value)
        {
            Console.Write(value);
        }
        
        public void Write(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }
    }
}
