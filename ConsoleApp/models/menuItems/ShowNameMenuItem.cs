using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class ShowNameMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        private readonly Person _person;

        /// <summary>
        /// Getter and setter title of show name menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        /// <param name="person"></param>
        public ShowNameMenuItem(Translate translate, Person person)
        {
            _translate = translate;
            _person = person;
            Title = _translate.ShowNameMenuItemTitle;
        }

        /// <summary>
        /// Handle show name action
        /// </summary>
        /// <returns></returns>
        public ItemReturn Handle()
        {
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
