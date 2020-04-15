using ConsoleApp.game;
using ConsoleApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ConsoleApp.models.menuItems;

namespace ConsoleApp.handlers
{
    internal class ConsoleHandler
    {
        private Translate _translate;

        private readonly Person _person = new Person();

        public static List<IMenuItem> MenuItems;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public ConsoleHandler(Translate translate)
        {
            _translate = translate;
        }

        /// <summary>
        /// Handle list input
        /// </summary>
        /// <returns></returns>
        public bool Options()
        {
            Console.Write(_translate.SelectMenuItem);
            var selected = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(selected, out var selectedNumber)) return false;
            var menuItem = MenuItems[selectedNumber];

            Console.WriteLine(_translate.YouSelected ,menuItem.Title);
            var itemReturn = menuItem.Handle();

            if (itemReturn.Translate != null)
            {
                _translate = itemReturn.Translate;
                FillList();
            }

            if (itemReturn.Exit) return false;
                
            Console.Write(_translate.PressAnyKey);
            Console.ReadKey();
            Console.Clear();

            return true;
        }

        /// <summary>
        /// Fill menu items list with the obj
        /// of the interface IMenuItem
        /// </summary>
        public void FillList()
        {
            MenuItems = new List<IMenuItem>
            {
                new AddMenuItem(_translate),
                new SubtractMenuItem(_translate),
                new DivideMenuItem(_translate),
                new ModuleMenuItem(_translate),
                new ShowNameMenuItem(_translate, _person),
                new InsertNameMenuItem(_translate, _person),
                new SnakeMenuItem(_translate),
                new TickTacToeMenuItem(_translate, _person),
                new TranslateMenuItem(_translate),
                new PetMenuItem(_translate),
                new CloseConsoleMenuItem(_translate)
            };
        }

        /// <summary>
        /// Show options list
        /// </summary>
        public void Intro()
        {
            Console.WriteLine(_translate.FirstName);
            Thread.Sleep(200);

            Console.WriteLine(_translate.FirstNameResult);
            _person.FirstName = Console.ReadLine();

            Thread.Sleep(500);

            Console.WriteLine(_translate.LastName);
            Thread.Sleep(200);

            Console.WriteLine(_translate.LastNameResult);
            _person.LastName = Console.ReadLine();
            Thread.Sleep(500);

            Console.Clear();

            Thread.Sleep(500);
            Console.WriteLine(_translate.Welcome, _person.FirstName +" "+ _person.LastName);
            
            Thread.Sleep(500);
            
            FillList();
        }

        /// <summary>
        /// Indexes the menu
        /// </summary>
        public void Menu()
        {
            Console.WriteLine(_translate.SelectOneOfTheList);
            for (var index = 0; index < MenuItems.Count; index++)
            {
                var menuItem = MenuItems[index];
                Console.WriteLine($"{index}: {menuItem.Title}");
            }
        }
    }
}


