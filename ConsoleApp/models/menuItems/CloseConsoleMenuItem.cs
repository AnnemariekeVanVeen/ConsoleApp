using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class CloseConsoleMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="translate"></param>
        public CloseConsoleMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.CloseConsoleMenuItemTitle;
        }

        /// <summary>
        /// Getter and setter title for close console menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Handle close console action
        /// </summary>
        /// <returns>bool</returns>
        public ItemReturn Handle()
        {
            return new ItemReturn { Exit = true };
        }
    }
}
