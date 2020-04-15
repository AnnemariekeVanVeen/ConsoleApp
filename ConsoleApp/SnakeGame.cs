using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ConsoleApp.handlers;

namespace ConsoleApp
{
    public partial class SnakeGame : Form
    {
        ///an array for the snake
        private List<Circle> Snake = new List<Circle>();
        ///creating a class from one circle that will be the food of the snake
        private Circle food = new Circle();

        public SnakeGame()
        {
            InitializeComponent();

            //Set settings to default
            new Settings();

            //Set game speed and start timer
            switch (Convert.ToString("b"))
            {
                case "B":
                    gameTimer.Interval = 800 / Settings.Speed;
                    break;
                case "I":
                    gameTimer.Interval = 600 / Settings.Speed;
                    break;
                case "A":
                    gameTimer.Interval = 400 / Settings.Speed;
                    break;
            }
            
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start New game
            StartGame();
        }

        /// <summary>
        /// Start the game
        /// </summary>
        private void StartGame()
        {
            //Game Over label is only visible when the game is over
            lblGameOver.Visible = false;

            //Set settings to default
            new Settings();

            //Create new player object
            Snake.Clear();
            Circle head = new Circle { X = 5, Y = 5 };
            Snake.Add(head);

            //the score is set to 0 in the beginning
            lblScore.Text = Settings.Score.ToString();

            //food for the snake generates when the game starts
            CreateFood();

        }

        /// <summary>
        /// Update the screen
        /// </summary>
        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check if the game is over
            if (Settings.GameOver)
            {
                //Check if enter is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                //if the game is not over, the following commands will be executed
                //a player can move his snake to a direction
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                //run the function moveplayer
                MovePlayer();
            }

            //update the screen
            pbCanvas.Invalidate();

        }

        /// <summary>
        /// Add graphics to the game
        /// </summary>
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Set colour of snake

                //Draw snake
                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    if (i == 0)
                    {
                        //head
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        //body
                        snakeColour = Brushes.BlueViolet; 
                    }

                    //Draw snake
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));


                    //Draw Food
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                             food.Y * Settings.Height, Settings.Width, Settings.Height));

                }
            }
            else
            {
                //this text will be displayed if the game is over
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        /// <summary>
        /// Let the player move
        /// </summary>
        private void MovePlayer()
        {
            //main loop for head and parts
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }


                    //Get maximum X and Y Position
                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    //Detect collission with game borders.
                    if (Snake[i].X < 0 || Snake[i].Y < 0
                        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        Die();
                    }


                    //Detect collission with body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //Detect collision with food piece
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();
                    }

                }
                else
                {
                    //Move body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        /// <summary>
        /// Executes when a key is pressed
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //this events triggers the change state from the input class
            Input.ChangeState(e.KeyCode, true);
        }

        /// <summary>
        /// Executes when an user releases a key
        /// </summary>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //this events triggers the change state from the input class
            Input.ChangeState(e.KeyCode, false);
        }

        /// <summary>
        /// Adds a circle to the snake
        /// </summary>
        private void Eat()
        {
            //Add a circle to body
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            //adding the new circle to the array
            Snake.Add(circle);

            //Update Score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            //run the generate food function
            CreateFood();
        }

        //Place random food object
        private void CreateFood()
        {
            //limits to the position where food can be placed
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            //new food is generated on a random position
            Random random = new Random();
            food = new Circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        /// <summary>
        /// Game Over
        /// </summary>
        private void Die()
        {
            //change the game over boolean to true
            Settings.GameOver = true;
        }
    }
}

