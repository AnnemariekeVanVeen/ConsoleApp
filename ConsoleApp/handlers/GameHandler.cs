using System.Collections;
using System.Windows.Forms;

namespace ConsoleApp.handlers
{
    internal class Input
    {
        private static Hashtable keyTable = new Hashtable();

        /// <summary>
        /// Look if a button is pressed
        /// This function returns a key back to the class
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }

            return (bool)keyTable[key];
        }

        /// <summary>
        /// Changes the state of the keys
        /// </summary>
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }

    /// <summary>
    /// enum class with directions for this game
    /// </summary>
    public enum Direction
    {
        Up, Down, Left, Right
    };

    public class Settings
    {
        /// <summary>
        /// Getter and setter width
        /// </summary>
        public static int Width { get; set; }

        /// <summary>
        /// Getter and setter height
        /// </summary>
        public static int Height { get; set; }
        
        /// <summary>
        /// Getter and setter speed
        /// </summary>
        public static int Speed { get; set; }
        

        /// <summary>
        /// Getter and setter score
        /// </summary>
        public static int Score { get; set; }
        
        /// <summary>
        /// Getter and setter points
        /// </summary>
        public static int Points { get; set; }
        
        /// <summary>
        /// Getter and setter game over
        /// </summary>
        public static bool GameOver { get; set; }
        
        /// <summary>
        /// Getter and setter direction
        /// </summary>
        public static Direction direction { get; set; }

        /// <summary>
        /// Default settings for the game
        /// </summary>
        public Settings()
        {
            Width = 15;
            Height = 15;
            Speed = 8;
            Score = 0;
            Points = 10;
            GameOver = false;
            direction = Direction.Down;
        }
    }
}
