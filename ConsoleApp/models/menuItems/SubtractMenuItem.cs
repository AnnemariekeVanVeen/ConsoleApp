﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.models.menuItems
{
    internal class SubtractMenuItem : IMenuItem
    {
        private readonly Calculator _calculator = new Calculator();

        private readonly Translate _translate;

        /// <summary>
        /// Getter and setter title of subtract menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public SubtractMenuItem(Translate translate)
        {
            _translate = translate;
            Title = _translate.SubtractMenuItemTitle;
        }

        /// <summary>
        /// Handle subtract action
        /// </summary>
        /// <returns></returns>
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

            var output = _calculator.Subtract();
            Console.Clear();
            Console.WriteLine(_translate.Result, _calculator.FirstValue + " - " + _calculator.SecondValue + " = " + output);

            return new ItemReturn { Exit = false };
        }
    }
}
