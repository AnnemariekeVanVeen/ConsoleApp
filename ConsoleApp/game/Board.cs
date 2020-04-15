using ConsoleApp.models;
using System;
using System.Collections.Generic;

namespace ConsoleApp.game
{
    public class Board
    {
        private readonly Person _person;

        private readonly Translate _translate;

        public Player HumanPlayer;

        public Player ComputerPlayer;

        public static readonly char NoPlayer = '?';

        public static readonly char Computer = 'O';

        public static readonly char Human = 'X';

        public char[,] GameBoard = { { '?', '?', '?' }, { '?', '?', '?' }, { '?', '?', '?' } };

        public Cell ComputerMove;

        /// <summary>
        /// Creates new human and computer.
        /// </summary>
        /// <param name="translate"></param>
        /// <param name="person"></param>
        public Board(Translate translate, Person person)
        {
            this._translate = translate;
            this._person = person;
            Title();
            this.HumanPlayer = new Player(PlayerName(), true, this, _translate);
            this.ComputerPlayer = new Player("Computer", false, this, _translate);

            Console.WriteLine(this.HumanPlayer + " " + ComputerPlayer);
        }

        /// <summary>
        /// Sets PlayerName with name that is filled in.
        /// </summary>
        /// <returns></returns>
        private string PlayerName()
        {
            Console.WriteLine("\n" + _translate.Note + "\n\n\n");
            string name = _person.FirstName;
            Console.WriteLine(_translate.YourNameIs, name);
            Console.WriteLine("\n" + _translate.KeyContinue);
            Console.ReadLine();

            return name;
        }

        /// <summary>
        /// Sets boolean for GameOver.
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            return HasWon(Computer) || HasWon(Human) || GetAvailableCells().Count == 0;
        }

        /// <summary>
        /// Sets boolean for cases in which player wins the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool HasWon(char player)
        {
            if ((GameBoard[0, 0] == GameBoard[1, 1] &&
                GameBoard[0, 0] == GameBoard[2, 2] &&
                 GameBoard[0, 0] == player) ||
                (GameBoard[0, 2] == GameBoard[1, 1] &&
                GameBoard[0, 2] == GameBoard[2, 0] &&
                 GameBoard[0, 2] == player))
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if ((GameBoard[i, 0] == GameBoard[i, 1] &&
                GameBoard[i, 0] == GameBoard[i, 2] &&
                 GameBoard[i, 0] == player) ||
                   (GameBoard[0, i] == GameBoard[1, i] &&
                GameBoard[0, i] == GameBoard[2, i] &&
                 GameBoard[0, i] == player))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Lists the available cells.
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetAvailableCells()
        {
            List<Cell> availableCells = new List<Cell>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i, j] == NoPlayer)
                    {
                        availableCells.Add(new Cell(i, j));
                    }
                }
            }
            return availableCells;
        }

        /// <summary>
        /// Set the boolean to check if cell is empty or not.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool PlaceMove(Cell cell, char player)
        {
            if (GameBoard[cell.x, cell.y] != Board.NoPlayer)
                return false;
            GameBoard[cell.x, cell.y] = player;
            return true;
        }

        /// <summary>
        /// Write the title.
        /// </summary>
        private static void Title()
        {
            Console.WriteLine("\t\t\t\tTIC TAC TOE\n\t\t\t\tversion 1.1\n");
        }

        /// <summary>
        /// Displays the board.
        /// </summary>
        public void Display()
        {
            Console.Clear();
            Title();
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t  A   B   C");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\t\t\t\t");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
                Console.Write("\t\t\t      ");
                Console.Write("{0} | ", i + 1);


                for (int j = 0; j < 3; j++)
                {
                    string value = "?";

                    if (GameBoard[i, j] == Computer)
                        value = "O";
                    else if (GameBoard[i, j] == Human)
                        value = "X";

                    Console.Write("{0} | ", value);
                }
                Console.WriteLine();
            }
            Console.Write("\t\t\t\t");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" ---");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Starts the game, handles the display of a new
        /// PlayerMove and writes the result of the game.
        /// </summary>
        public void Start()
        {
            Console.Title = _translate.Title;
            Display();

            while (!IsGameOver())
            {
                HumanPlayer.GetPlayerMove();
                Display();

                if (IsGameOver())
                {
                    break;
                }

                ComputerPlayer.GetPlayerMove();
                Display();

                if (IsGameOver())
                {
                    break;
                }
            }

            if (HasWon(Board.Computer))
            {
                Console.WriteLine(_translate.LostGame);
            }
            else if (HasWon(Board.Human))
            {
                Console.WriteLine(_translate.WonGame);
            }
            else
            {
                Console.WriteLine(_translate.DrawGame);
            }
        }
    }
}
