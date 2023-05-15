using nsPlayer;
using nsCell;
using nsGrid;
using static System.Net.Mime.MediaTypeNames;

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

            //TODO: MAKE THE GAME LOOP WITH OBJECTS
            while (!gameComplete)
            {
                gameComplete = PlayGame(playerList, playGrid);
            }
        }

        // Greeting and setup
        public static void InitGame(List<Player> players, Grid grid)
        {
            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();

            // Let the user choose how many players and create them.
            int numPlayers = CheckInt("How many players?", 2, 10);

            for (int i = 0; i < numPlayers; i++) {
                string playerName = "";
                while (playerName == "")
                    {
                        Console.WriteLine("Please enter the name of player {0}:", i + 1);
                        playerName = Console.ReadLine();
                    }
                Console.WriteLine();

                Console.WriteLine(playerName + ", choose your marker.");
                char playerMarker = CheckChar();
                bool dupMarker = true;
                while (dupMarker)
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
                            dupMarker = false;
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

            //Grid playGrid = new Grid(gridRows, gridCols);
            grid.CreateGrid(gridRows, gridCols);
            grid.DrawGrid();
            Console.WriteLine();

            Console.WriteLine("Press [ENTER] to begin the game...");
            Console.ReadLine();
            Console.Clear();

            // playGame(player1, playGrid);
        }

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

        public static char CheckChar()
        {
            char x = 'x';
            Console.WriteLine("Please enter a single character. (Example: X)");
            if (!char.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Please enter a single character. (Example: X)");
            }
            return x;
        }

        public static bool PlayGame(List<Player> players, Grid grid)
        {
            foreach (Player p in players)
            {
                Console.Clear();
                grid.DrawGrid();
                Console.WriteLine();
                Console.WriteLine("########################");
                Console.WriteLine($"{p.Name}, it is your turn!");
                Console.WriteLine("To place your marker in a space you will first select the row, then the column.");
                Console.WriteLine();

                bool invalidMove = true;
                while (invalidMove)
                {
                    int moveRow = CheckInt("Select your row.", 1, grid.NumRows);
                    int moveCol = CheckInt("Select your column.", 1, grid.NumCols);
                    invalidMove = grid.MakeMove(p, moveRow, moveCol);
                }

                // TODO: Logic for detecting a winner goes here.
                if (grid.CheckWin(p))
                {
                    // IF WINNER FOUND
                    break;
                }

                Console.WriteLine("Your turn is complete!");
                Console.WriteLine("Press [ENTER] to go to the next player...");
                Console.ReadLine();
            }
        }
    }
}