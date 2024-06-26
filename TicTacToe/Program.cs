﻿using nsPlayer;
using nsGrid;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>();
            Grid playGrid = new Grid();

            InitGame(playerList, playGrid);

            bool gameComplete = false;

            // Main game loop
            while (!gameComplete)
            {
                gameComplete = PlayGame(playerList, playGrid);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to close the game...");
            Console.ReadLine();
        }

        /// <summary>
        /// Greeting and game setup.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="grid"></param>
        public static void InitGame(List<Player> players, Grid grid)
        {
            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();

            // Let the user choose how many players and create them.
            int numPlayers = CheckInt("How many players?", 2, 5);

            for (int i = 0; i < numPlayers; i++)
            {
                string playerName = "";
                bool dupCheck = true;
                while (playerName == "" || dupCheck)
                    {
                        Console.WriteLine("Please enter the name of player {0}:", i + 1);
                        playerName = Console.ReadLine();
                        Player nameCheck = players.Find(objPlayer => objPlayer.Name == playerName);
                        if (nameCheck != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("This name has already been chosen. Please choose a different name.");
                            //playerName = Console.ReadLine();
                        }
                        else
                        {
                            dupCheck = false;
                        }
                    }
                Console.WriteLine();
                Console.WriteLine(playerName + ", choose your marker.");
                char playerMarker = CheckChar();
                dupCheck = true;
                while (dupCheck)
                    {
                        Player markerCheck = players.Find(objPlayer => objPlayer.Marker == playerMarker);
                        if (markerCheck != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("This marker has already been chosen. Please choose a different marker.");
                            playerMarker = CheckChar();
                        }
                        else
                        {
                            dupCheck = false;
                        }
                    }
                players.Add(new Player(playerName, playerMarker));
                Console.WriteLine();
                Console.WriteLine("###################################");
                Console.WriteLine($"Player created! {playerName} is {playerMarker}.");
                Console.WriteLine("###################################");
                Console.WriteLine();
            }

            // Let the user choose how many columns and rows to place in the game grid.
            int gridRows = CheckInt("How many rows would you like in the game board?", 3, 20);
            int gridCols = CheckInt("How many columns would you like in the game board?", 3, 20);

            grid.CreateGrid(gridRows, gridCols);
            Console.WriteLine();
            Console.WriteLine("###################################");
            Console.WriteLine("Created {0} players and a board that is {1} by {2}!", numPlayers, gridRows, gridCols);
            Console.WriteLine("###################################");
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to begin the game...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Check for a valid integer for moving.
        /// </summary>
        /// <param name="promptMsg"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static int CheckInt(string promptMsg, int minVal, int maxVal)
        {
            Console.WriteLine(promptMsg);
            int x = 0;
            while (x < minVal || x > maxVal)
            {
                Console.WriteLine("Please enter a number between {0} and {1}.", minVal, maxVal);
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Please enter a number between {0} and {1}.", minVal, maxVal);
                }
            }
            Console.WriteLine();
            return x;
        }

        /// <summary>
        /// Verify that player marker is valid.
        /// </summary>
        /// <returns></returns>
        public static char CheckChar()
        {
            char x = 'x';
            string input = "";
            bool isValid = false;

            while (!isValid || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a single character. (Example: X)");
                input = Console.ReadLine().Trim();
                isValid = char.TryParse(input, out x);
            }
            return x;
        }

        /// <summary>
        /// Primary game loop.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static bool PlayGame(List<Player> players, Grid grid)
        {
            int totalSpaces = grid.NumRows * grid.NumCols;
            foreach (Player p in players)
            {
                Console.Clear();
                grid.DrawGrid();
                Console.WriteLine();
                Console.WriteLine("###################################");
                Console.WriteLine($"{p.Name}, it is your turn!");
                Console.WriteLine("To place your marker in a space you will first select the row, then the column.");
                Console.WriteLine();

                bool validMove = false;
                while (!validMove)
                {
                    int moveRow = CheckInt("Select your row.", 1, grid.NumRows);
                    int moveCol = CheckInt("Select your column.", 1, grid.NumCols);
                    validMove = grid.MakeMove(p, moveRow, moveCol);
                }
                grid.MovesMade++;

                // Check for winner
                if (grid.CheckWin(p))
                {
                    return true;
                } else if (grid.MovesMade == totalSpaces) {
                    Console.WriteLine();
                    Console.WriteLine("###################################");
                    Console.WriteLine("The game resulted in a tie!");
                    Console.WriteLine("###################################");
                    return true;
                }

                Console.WriteLine("Your turn is complete!");
                Console.WriteLine("Press [ENTER] to go to the next player...");
                Console.ReadLine();
            }

            return false;
        }
    }
}