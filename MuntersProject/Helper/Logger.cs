using System;


namespace MuntersProject.Extensions
{
    public class Logger
    {
        public static void PrintLog(string text)
        {
            var currentTime = DateTime.Now;
            Console.WriteLine($"{currentTime}: {text}");
        }
    }
}
