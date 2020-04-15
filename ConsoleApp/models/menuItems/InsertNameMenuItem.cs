using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class InsertNameMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        private readonly Person _person;

        /// <summary>
        /// Getter and setter insert name menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        /// <param name="person"></param>
        public InsertNameMenuItem(Translate translate, Person person)
        {
            _translate = translate;
            _person = person;
            Title = _translate.InsertNameMenuItemTitle;
        }

        /// <summary>
        /// Handle insert name action
        /// </summary>
        /// <returns>Bool</returns>
        public ItemReturn Handle()
        {
            Console.Write(_translate.FirstName);
            _person.FirstName = Console.ReadLine();

            Console.Write(_translate.LastName);
            _person.LastName = Console.ReadLine();

            Console.Clear();

            if (_person.FirstName == null && _person.LastName == null)
            {
                Console.WriteLine(_translate.NoNameError);
                return new ItemReturn { Exit = false };
            }
            Console.Clear();
            Console.WriteLine(_translate.YourNameIs, _person.FirstName + " " + _person.LastName);

            return new ItemReturn { Exit = false };
        }
    }
}
