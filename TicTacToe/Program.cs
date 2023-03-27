namespace TicTacToe
{

    public class Player
    {
        public string Name { get; set; }
        public char Marker { get; set; }

        public Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
        }
    }

    public class Grid
    {
        public List<char> GridValues = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public void DrawGrid()
        {
            Console.WriteLine($" {GridValues[0]} | {GridValues[1]} | {GridValues[2]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {GridValues[3]} | {GridValues[4]} | {GridValues[5]} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {GridValues[6]} | {GridValues[7]} | {GridValues[8]} ");
        }

        public string MakeMove(Player player, int space)
        {
            // TODO: validate the move, set the marker, or return a string with validation error message
            return ""; // empty string means no error (part of our game design, not a feature of C#)
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            initGame();

            Grid playGrid = new Grid();

            //bool gameComplete = false;
            //var curPlayer = player1;


            // TODO: MAKE THE GAME LOOP WITH OUR OBJECTS **HOW TO SOLVE SCOPE WITHOUT INITGAME IN MAIN
            //while (gameComplete == false)
            //{
            //    playGame(Player curPlayer, Grid playGrid);
            //}

        }

        // Greeting and setup
        public static void initGame()
        {
            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            string player1name = "";
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
            Console.WriteLine("#####");
            Console.WriteLine($"Player 1 created! {player1.Name} is {player1.Marker}.");
            Console.WriteLine("#####");
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
            Console.WriteLine("#####");
            Console.WriteLine($"Player 2 created! {player2.Name} is {player2.Marker}.");
            Console.WriteLine("#####");
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to begin the game...");
            Console.Read();
            Console.Clear();

            // playGame(player1, playGrid);
        }

        public static void playGame(Player curPlayer, Grid gameBoard)
        {
            gameBoard.DrawGrid();
            Console.WriteLine();
            Console.WriteLine($"{curPlayer.Name}, it is your turn!");
            Console.WriteLine("Please select an unoccupied square on the game to make a move.");
        }
    }
}