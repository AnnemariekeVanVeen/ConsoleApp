using System;
using System.Collections.Generic;

namespace ConsoleApp.game
{
    class AI
    {
        private readonly Board _b;

        /// <summary>
        /// Set board object
        /// </summary>
        /// <param name="board"></param>
        public AI(Board board)
        {
            this._b = board;
        }

        /// <summary>
        /// Recursive AI function to decide which cell to fill as best move.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="turn"></param>
        /// <returns></returns>
        public int MinMax(int depth, char turn)
        {
            // Checks if computer has won
            if (_b.HasWon(Board.Computer))
            {
                return 1;
            }
            // Checks if human has won
            if (_b.HasWon(Board.Human))
            {
                return -1;
            }

            // List of the available cells 
            List<Cell> availableCells = _b.GetAvailableCells();

            // If there are no cells left, return 0
            if (availableCells.Count == 0)
            {
                return 0;
            }

            // Set values of min and max with counter value to help calculate the best move
            int min = int.MaxValue;
            int max = int.MinValue;

            // Loops over available cells
            for (int i = 0; i < availableCells.Count; i++)
            {
                // Set cell to availableCell with index of i
                Cell cell = availableCells[i];

                // If turn is for Computer
                if (turn == Board.Computer)
                {
                    // Place move
                    _b.PlaceMove(cell, Board.Computer);

                    // Set currentScore with call of recursive function for human turn
                    int currentScore = MinMax(depth + 1, Board.Human);

                    // Set max to the highest score, either currentScore or max
                    max = Math.Max(currentScore, max);

                    // If currentScore is 0 or bigger than 0 and depth is 0, place move
                    if (currentScore >= 0)
                    {
                        if (depth == 0)
                        {
                            _b.ComputerMove = cell;
                        }
                    }
                    // If currentScore is 1, fill cell with ? again and break loop
                    if (currentScore == 1)
                    {
                        _b.GameBoard[cell.x, cell.y] = Board.NoPlayer;
                        break;
                    }
                    // If no options left and depth is 0, place move
                    if (i == availableCells.Count - 1 && max < 0)
                    {
                        if (depth == 0)
                        {
                            _b.ComputerMove = cell;
                        }
                    }
                }
                // If statement for turn is for human
                else if (turn == Board.Human)
                {
                    // Place move for human
                    _b.PlaceMove(cell, Board.Human);

                    // Call recursive function with turn for computer and go one layer deeper (depth + 1)
                    int currentScore = MinMax(depth + 1, Board.Computer);

                    // Set min to the highest score, either currentScore or min
                    min = Math.Min(currentScore, min);

                    // If min is -1, fill cell with ? and break the loop
                    if (min == -1)
                    {
                        _b.GameBoard[cell.x, cell.y] = Board.NoPlayer;
                        break;
                    }
                }
                // Clear cell by setting it to ? again
                _b.GameBoard[cell.x, cell.y] = Board.NoPlayer;
            }
            // If turn is for Computer return max, else return min
            return turn == Board.Computer ? max : min;
        }
    }

}
