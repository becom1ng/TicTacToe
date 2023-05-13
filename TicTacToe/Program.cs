using nsPlayer;
using nsCell;
using nsGrid;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitGame();

            //Grid playGrid = new Grid();

            //bool gameComplete = false;
            //var curPlayer = player1;


            // TODO: MAKE THE GAME LOOP WITH OUR OBJECTS **HOW TO SOLVE SCOPE WITHOUT INITGAME IN MAIN
            //while (gameComplete == false)
            //{
            //    PlayGame(Player curPlayer, Grid playGrid);
            //}

        }

        // Greeting and setup
        public static void InitGame()
        {
            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();

            //  TODO: Let the user choose how many players

            int numPlayers = CheckInt("How many players?", 2);

            for (int i = 1; i < numPlayers + 1; i++) {
                string playerName = "";
                while (playerName == "")
                    {
                        Console.WriteLine("Please enter the name of player {0}:");
                        playerName = Console.ReadLine();
                    }
                Console.WriteLine();
                char playerMarker = '';
                while (playerMarker = '')
                    {
                        Console.WriteLine(playerName + ", choose your marker. (Example: X)");
                        if (!char.TryParse(Console.ReadLine(), out playerMarker))
                        {
                            Console.WriteLine(playerName + ", choose your marker. (Example: X)");
                        }
                    }
                Player player1 = new Player(playerName, playerMarker);
                Console.WriteLine();
                Console.WriteLine("###################################");
                Console.WriteLine($"Player {i} created! {player1.Name} is {player1.Marker}.");
                Console.WriteLine("###################################");
                Console.WriteLine();
            }

            /*string player1name = "";
            while (player1name == "")
                {
                    Console.WriteLine("Please enter the name of player 1:");
                    player1name = Console.ReadLine();
                }
            Console.WriteLine();
            char player1marker = 'a';
            while (!(player1marker == 'X' || player1marker == 'O'))
                {
                    Console.WriteLine(player1name + ", choose your marker (X or O):");
                    if (!char.TryParse(Console.ReadLine(), out player1marker))
                    {
                        Console.WriteLine(player1name + ", choose your marker (X or O):");
                    }
                }
            Player player1 = new Player(player1name, player1marker);
            Console.WriteLine();
            Console.WriteLine("###################################");
            Console.WriteLine($"Player 1 created! {player1.Name} is {player1.Marker}.");
            Console.WriteLine("###################################");
            Console.WriteLine();

            string player2name = "";
            while (player2name == "")
                {
                    Console.WriteLine("Please enter the name of player 2:");
                    player2name = Console.ReadLine();
                }
            char player2marker = 'a';
                if (player1.Marker == 'X')
                {
                    player2marker = 'O';
                } else {
                    player2marker = 'X';
                }
            Player player2 = new Player(player2name, player2marker);
            Console.WriteLine();
            Console.WriteLine("###################################");
            Console.WriteLine($"Player 2 created! {player2.Name} is {player2.Marker}.");
            Console.WriteLine("###################################");
            Console.WriteLine();*/

                // Let the user choose how many columns and rows to place in the game grid.

                int gridRows = CheckInt("How many rows would you like in the game board?", 3);
            int gridCols = CheckInt("How many columns would you like in the game board?", 3);

            Grid playGrid = new Grid(gridRows, gridCols);

            playGrid.DrawGrid();





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

        public static void PlayGame(Player curPlayer, Grid gameBoard)
        {
            //gameBoard.DrawGrid();
            Console.WriteLine();
            Console.WriteLine($"{curPlayer.Name}, it is your turn!");
            Console.WriteLine("Please select an unoccupied square on the game to make a move.");
        }
    }
}