using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.game;

namespace ConsoleApp.models.menuItems
{
    internal class TickTacToeMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        private readonly Person _person;

        /// <summary>
        /// Getter and setter title of tick tac toe menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        /// <param name="person"></param>
        public TickTacToeMenuItem(Translate translate, Person person)
        {
            _translate = translate;
            _person = person;
            Title = _translate.TickTacToeMenuItemTitle;
        }

        /// <summary>
        /// Handle tick tac toe action
        /// </summary>
        /// <returns></returns>
        public ItemReturn Handle()
        {
            var b = new Board(_translate, _person);
            b.Start();

            return new ItemReturn { Exit = false };
        }
    }
}
