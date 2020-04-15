using ConsoleApp.handlers;
using System;
using System.Windows.Forms;


namespace ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        private static void Main()
        {
            var exit = true;
            var consoleHandler = new ConsoleHandler(TranslateHandler.LoadJson("EN"));

            Console.WriteLine("Welcome to the AD software developer assignment");

            consoleHandler.Intro();

            while (exit)
            {
                consoleHandler.Menu();

                exit = consoleHandler.Options();
            }
        }
    }
}

