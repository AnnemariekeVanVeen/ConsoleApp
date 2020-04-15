using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class PetMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        /// <summary>
        /// Getter and setter title pet menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="translate"></param>
        public PetMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.PetMEnuItemTitle;
        }

        /// <summary>
        /// Handle pet action
        /// </summary>
        /// <returns>bool</returns>
        public ItemReturn Handle()
        {
            IPet pet = null;
            Console.WriteLine(_translate.PetIs);
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    pet = new Cat(_translate);
                    break;
                case 2:
                    pet = new Dog(_translate);
                    break;
            }

            if (pet == null)
            {
                Console.Clear();
                Console.WriteLine(_translate.InputTypeError);
                return new ItemReturn { Exit = false };
            }

            Console.Write(_translate.PetName);
            var name = Console.ReadLine()?.ToString();
            pet.Name = name;
            Console.Clear();
            pet.Talk();

            return new ItemReturn { Exit = false };
        }
    }
}
