using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp.models.menuItems
{
    internal class SnakeMenuItem : IMenuItem
    {
        private readonly Translate _translate;

        private readonly Circle _level = new Circle();

        /// <summary>
        /// Getter and setter title of snake menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public SnakeMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.SnakeMenuItemTitle;
        }

        /// <summary>
        /// Handle snake action
        /// </summary>
        /// <returns></returns>
        public ItemReturn Handle()
        {
            Console.WriteLine(_translate.Level);
            Console.WriteLine(_translate.ChooseLevel);
            _level.Level = Console.ReadLine();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnakeGame());

            return new ItemReturn { Exit = false };
        }
    }
}
