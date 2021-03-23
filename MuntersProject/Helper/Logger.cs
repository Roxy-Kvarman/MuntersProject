using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MuntersProject.Extensions
{
    public class Logger
    {
        public static void PrintLog(string text)
        {
            var currentTime = DateTime.Now;
            Console.WriteLine($"{currentTime}: {text}");
        }
        public static void PrintInfo(string text)
        {
            Console.WriteLine(text);
        }
    }
}
