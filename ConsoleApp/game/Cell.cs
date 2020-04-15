namespace ConsoleApp.game
{
    public struct Cell
    {
        public int x;

        public int y;

        /// <summary>
        /// Set x-axis and y-axis of Cell.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
