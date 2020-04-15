namespace ConsoleApp
{
    class Circle
    {
        /// <summary>
        /// Getter and setter X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Getter and setter Y
        /// </summary>
        public int Y { get; set; }
        
        /// <summary>
        /// Getter and setter level
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// function to reset X and Y to 0
        /// </summary>
        public Circle()
        {
            X = 0;
            Y = 0;
        }
    }

}
