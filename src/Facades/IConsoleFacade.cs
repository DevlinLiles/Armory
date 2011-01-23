using System;

namespace Armory.Facades
{
    public interface IConsoleFacade
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        string Title { get; set; }
        void Clear();
        int Read();
        ConsoleKeyInfo ReadKey(bool intercept = false);
        string ReadLine();
        void ResetColor();
        void Write<T>(T value);
        void Write(string format, params object[] arg);
        void WriteLine();
        void WriteLine<T>(T value);
        void WriteLine(string format, params object[] arg);
    }
}
