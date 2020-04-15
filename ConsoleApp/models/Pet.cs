using System;

namespace ConsoleApp.models
{
    public interface IPet
    {
        /// <summary>
        /// Getter and setter name for a pet
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// function to talk as the pet
        /// </summary>
        void Talk();
    }

    public class Cat : IPet
    {
        private readonly Translate _translate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public Cat(Translate translate)
        {
            this._translate = translate;

        }

        /// <summary>
        /// Getter and setter name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Talk as cat function
        /// </summary>
        public void Talk()
        {
            Console.WriteLine(_translate.CatText, Name);
        }
    }

    public class Dog : IPet
    {
        private readonly Translate _translate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="translate"></param>
        public Dog(Translate translate)
        {
            this._translate = translate;

        }

        /// <summary>
        /// Getter and setter name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Talk as dog
        /// </summary>
        public void Talk()
        {
            Console.WriteLine(_translate.DogText, Name);
        }
    }
}
