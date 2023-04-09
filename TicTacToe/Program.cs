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

    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Marker { get; set; }

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
            Marker = ' ';
        }
    }

    public class Grid
    {
        public int NumRows { get; set; }
        public int NumCols { get; set;  }

        public List<Cell> Cells { get; private set; }

        public Grid(int rows, int cols)
        {
            CreateGrid(rows, cols);
            NumRows = rows;
            NumCols = cols;
        }

        private void CreateGrid(int rows, int cols)
        {
            Cells = new List<Cell>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                    {
                    //Console.WriteLine("Adding Cell with: r = {0}, c = {1}", r, c);
                    Cells.Add(new Cell(r, c));
                    }
            }

            /*foreach (Cell cell in Cells)
            {
                Console.WriteLine("Cell: row = {0}, col = {1}, marker = {2}", cell.Row, cell.Column, cell.Marker);
            }*/
        }

        public void DrawGrid()
        {
            for (int r = 0; r < NumRows; r++)
            {
                for (int c = 0; c < NumCols; c++)
                {
                    Cell objFound = Cells.Find(oCell => oCell.Row.Equals(r) && oCell.Column.Equals(c));
                    if (objFound != null)
                    {
                        Console.Write(" {0} ", objFound.Marker);
                    }

                    if (c < NumCols - 1)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (r < NumRows - 1)
                {
                    for (int c = 0; c < NumCols; c++)
                    {
                        Console.Write("---");
                        if (c < NumCols - 1)
                        {
                            Console.Write("+");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public string MakeMove(Player player, int space)
        {
            // TODO: validate the move, set the marker, or return a string with validation error message
            return ""; // empty string means no error (part of our game design, not a feature of C#)
        }

        // TODO: add the other method ideas for things to do on a game grid
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            initGame();

            //Grid playGrid = new Grid();

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
            //  TODO: Let the user choose how many players

            Console.WriteLine("########################");
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
/*            string player1name = "";
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

            // TODO: Let the user choose how many columns and rows to place in the game grid.

            int gridRows = 0;
            int gridCols = 0;
            while (gridRows < 3)
            {
                Console.WriteLine("How many rows would you like in the game board (min 3)?");
                if (!int.TryParse(Console.ReadLine(), out gridRows))
                {
                    Console.WriteLine("How many rows would you like in the game board (min 3)?");
                }
            }
            Console.WriteLine();
            while (gridCols < 3)
            {
                Console.WriteLine("How many columns would you like in the game board (min 3)?");
                if (!int.TryParse(Console.ReadLine(), out gridCols))
                {
                    Console.WriteLine("How many columns would you like in the game board (min 3)?");
                }
            }
            Console.WriteLine();

            Grid playGrid = new Grid(gridRows, gridCols);

            playGrid.DrawGrid();












            Console.WriteLine("Press [ENTER] to begin the game...");
            Console.Read();
            Console.Clear();

            // playGame(player1, playGrid);
        }

        public static void playGame(Player curPlayer, Grid gameBoard)
        {
            //gameBoard.DrawGrid();
            Console.WriteLine();
            Console.WriteLine($"{curPlayer.Name}, it is your turn!");
            Console.WriteLine("Please select an unoccupied square on the game to make a move.");
        }
    }
}