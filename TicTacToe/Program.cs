using nsPlayer;
using nsCell;
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

            //bool gameComplete = false;
            //var curPlayer = player1;


            //TODO: MAKE THE GAME LOOP WITH OUR OBJECTS **HOW TO SOLVE SCOPE WITHOUT INITGAME IN MAIN
            //while (gameComplete == false)
            //{
            //    PlayGame(Player curPlayer, Grid playGrid);
            //}

        }

        // Greeting and setup
        public static void InitGame(List<Player> players, Grid grid )
        {
            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();

            // Let the user choose how many players and create them.
            int numPlayers = CheckInt("How many players?", 2);

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
            int gridRows = CheckInt("How many rows would you like in the game board?", 3);
            int gridCols = CheckInt("How many columns would you like in the game board?", 3);

            //Grid playGrid = new Grid(gridRows, gridCols);
            grid.CreateGrid(gridRows, gridCols);
            grid.DrawGrid();
            Console.WriteLine();

            Console.WriteLine("Press [ENTER] to begin the game...");
            Console.Read();
            Console.Clear();

            // playGame(player1, playGrid);
        }

        public static int CheckInt(string promptMsg, int minVal)
        {
            Console.WriteLine(promptMsg);
            int x = 0;
            while (x < minVal)
            {
                Console.WriteLine("Please enter a number (min {0}).", minVal);
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Please enter a number (min {0}).", minVal);
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

        public static void PlayGame(Player curPlayer, Grid gameBoard)
        {
            //gameBoard.DrawGrid();
            Console.WriteLine();
            Console.WriteLine($"{curPlayer.Name}, it is your turn!");
            Console.WriteLine("Please select an unoccupied square on the game to make a move.");
        }
    }
}