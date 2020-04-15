namespace ConsoleApp.models
{
    internal class Calculator
    {
        /// <summary>
        /// Getter and setter first value
        /// </summary>
        public double FirstValue { get; set; }

        /// <summary>
        /// Getter and setter second value
        /// </summary>
        public double SecondValue { get; set; }

        /// <summary>
        /// Add second value to the first value
        /// </summary>
        /// <returns>double</returns>
        public double Add()
        {
            return FirstValue + SecondValue;
        }

        /// <summary>
        /// Subtract second value from first value
        /// </summary>
        /// <returns>double</returns>
        public double Subtract()
        {
            return FirstValue - SecondValue;
        }

        /// <summary>
        /// Divide second value from first value
        /// </summary>
        /// <returns>double</returns>
        public double Divide()
        {
            return FirstValue / SecondValue;
        }

        /// <summary>
        /// Module second value from first value
        /// </summary>
        /// <returns>double</returns>
        public double Module()
        {
            return FirstValue % SecondValue;
        }
    }
}
