
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class AddMenuItem : IMenuItem
    {
        private readonly Calculator _calculator = new Calculator();

        private readonly Translate _translate;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="translate"></param>
        public AddMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.AddMenuItemTitle;
        }

        /// <summary>
        /// Getter of the title for menu
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Handle add option
        /// </summary>
        /// <returns>bool</returns>
        public ItemReturn Handle()
        {
            try
            {
                Console.Write(_translate.FirstValue);
                _calculator.FirstValue = Convert.ToDouble(Console.ReadLine());

                Console.Write(_translate.SecondValue);
                _calculator.SecondValue = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(_translate.InputTypeError);
                this.Handle();
            }
            catch (OverflowException)
            {
                Console.WriteLine(_translate.OverflowError);
                this.Handle();
            }
            catch (Exception)
            {
                Console.WriteLine(_translate.Error);
                this.Handle();
            }
            

            var output = _calculator.Add();
            Console.Clear();
            Console.WriteLine(_translate.Result, _calculator.FirstValue + " + " + _calculator.SecondValue + " = " + output);

            return new ItemReturn { Exit = false };
        }
    }
}
