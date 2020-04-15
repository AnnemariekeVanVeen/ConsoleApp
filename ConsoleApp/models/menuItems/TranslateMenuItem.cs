using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.handlers;

namespace ConsoleApp.models.menuItems
{
    internal class TranslateMenuItem : IMenuItem
    { 
        private Translate _translate;

        /// <summary>
        /// Getter and setter title of translate menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public TranslateMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.TranslateMenuItemTitle;
        }

        /// <summary>
        /// Handle translate action
        /// </summary>
        /// <returns></returns>
        public ItemReturn Handle()
        {
            Console.WriteLine(_translate.ChooseTrans);
            Console.WriteLine(_translate.Line);
            Console.WriteLine(_translate.EnterInput);
            var region = Console.ReadLine();
            try
            {
                _translate = TranslateHandler.LoadJson(region);
                Console.Clear();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(_translate.FileNotFoundError);
            }

            return new ItemReturn
            {
                Exit = false,
                Translate = _translate
            };
        }
    }
}
