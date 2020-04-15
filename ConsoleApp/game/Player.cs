using ConsoleApp.models;
using System;
using System.Threading;

namespace ConsoleApp.game
{
    public class Player
    {
        private readonly string _name;

        private readonly char _marker;

        private readonly bool _human;

        private readonly Translate _translate;

        private readonly Board _board;

        private readonly AI _bot;

        /// <summary>
        /// Sets translate, name, marker, human, board (b) and AI (mm).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="human"></param>
        /// <param name="board"></param>
        /// <param name="translate"></param>
        public Player(string name, bool human, Board board, Translate translate)
        {
            this._translate = translate;
            this._name = name;
            this._marker = human ? 'X' : 'O';
            this._human = human;
            this._board = board;
            this._bot = new AI(this._board);
        }

        /// <summary>
        /// Getter name
        /// </summary>
        /// <returns>_name</returns>
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Getter marker
        /// </summary>
        /// <returns>_marker</returns>
        public char GetMarker()
        {
            return _marker;
        }

        /// <summary>
        /// Getter boolean human 
        /// </summary>
        /// <returns>_human</returns>
        public bool IsHuman()
        {
            return _human;
        }

        /// <summary>
        /// Getter PlayerMove
        /// </summary>
        public void GetPlayerMove() //get the currentPlayer Move
        {
            if (this.IsHuman())
            {
                GetHumanMove();
            }
            else
            {
                GetComputerMove();
            }
        }

        /// <summary>
        /// Getter HumanMove
        /// </summary>
        private void GetHumanMove()
        {
            var moveOk = true;

            var cell = new Cell();

            do
            {
                string move;

                if (!moveOk)
                {
                    Console.WriteLine(_translate.CellFilled);
                }
                do
                {
                    Console.Write(this + ":");
                    move = Console.ReadLine();
                    move = move.ToUpper();

                    switch (move)
                    {
                        case "A1":
                            {
                                cell.x = 0; cell.y = 0;
                                break;
                            }
                        case "A2":
                            {
                                cell.x = 1; cell.y = 0;
                                break;
                            }
                        case "A3":
                            {
                                cell.x = 2; cell.y = 0;
                                break;
                            }
                        case "B1":
                            {
                                cell.x = 0; cell.y = 1;
                                break;
                            }
                        case "B2":
                            {
                                cell.x = 1; cell.y = 1;
                                break;
                            }
                        case "B3":
                            {
                                cell.x = 2; cell.y = 1;
                                break;
                            }
                        case "C1":
                            {
                                cell.x = 0; cell.y = 2;
                                break;
                            }
                        case "C2":
                            {
                                cell.x = 1; cell.y = 2;
                                break;
                            }
                        case "C3":
                            {
                                cell.x = 2; cell.y = 2;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(_translate.WrongMove);
                                break;
                            }
                    }
                }
                while (move != "A1" && move != "A2" && move != "A3" &&
                   move != "B1" && move != "B2" && move != "B3" &&
                   move != "C1" && move != "C2" && move != "C3");


                moveOk = _board.PlaceMove(cell, Board.Human);
            }
            while (!moveOk);
        }

        /// <summary>
        /// Getter ComputerMove
        /// </summary>
        private void GetComputerMove()
        {
            _bot.MinMax(0, this.GetMarker());
            _board.PlaceMove(_board.ComputerMove, Board.Computer);

            if (_board.ComputerMove.Equals(new Cell(0, 0)))
            {
                Console.WriteLine(this + ": A1");

            }
            else if (_board.ComputerMove.Equals(new Cell(1, 0)))
            {
                Console.WriteLine(this + ": A2");
            }
            else if (_board.ComputerMove.Equals(new Cell(2, 0)))
            {
                Console.WriteLine(this + ": A3");
            }
            else if (_board.ComputerMove.Equals(new Cell(0, 1)))
            {
                Console.WriteLine(this + ": B1");
            }
            else if (_board.ComputerMove.Equals(new Cell(1, 1)))
            {
                Console.WriteLine(this + ": B2");
            }
            else if (_board.ComputerMove.Equals(new Cell(2, 1)))
            {
                Console.WriteLine(this + ": B3");
            }
            else if (_board.ComputerMove.Equals(new Cell(0, 2)))
            {
                Console.WriteLine(this + ": C1");
            }
            else if (_board.ComputerMove.Equals(new Cell(1, 2)))
            {
                Console.WriteLine(this + ": C2");
            }
            else if (_board.ComputerMove.Equals(new Cell(2, 2)))
            {
                Console.WriteLine(this + ": C3");
            }
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Override string with marker.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetName() + "(" + this.GetMarker() + ")";
        }
    }
}
