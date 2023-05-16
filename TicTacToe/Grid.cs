using nsPlayer;
using nsCell;

namespace nsGrid
{
    public class Grid
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public int MovesMade { get; set; }

        public List<Cell> Cells { get; private set; }

        public void CreateGrid(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            MovesMade = 0;
            Cells = new List<Cell>();
            for (int r = 1; r < rows + 1; r++)
            {
                for (int c = 1; c < cols + 1; c++)
                {
                    Cells.Add(new Cell(r, c));
                }
            }
        }

        public void DrawGrid()
        {
            for (int r = 1; r < NumRows + 1; r++)
            {
                for (int c = 1; c < NumCols + 1; c++)
                {
                    Cell objFound = Cells.Find(objCell => objCell.Row == r && objCell.Column == c);
                    if (objFound != null)
                    {
                        Console.Write(" {0} ", objFound.Marker);
                    }

                    if (c < NumCols)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (r < NumRows)
                {
                    for (int c = 1; c < NumCols + 1; c++)
                    {
                        Console.Write("---");
                        if (c < NumCols)
                        {
                            Console.Write("+");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public bool MakeMove(Player player, int r, int c)
        {
            Cell objFound = Cells.Find(objCell => objCell.Row == r && objCell.Column == c && objCell.Marker == ' ');
            if (objFound != null) // Cell is blank
            {
                objFound.Marker = player.Marker;
                Console.WriteLine("###################################");
                Console.WriteLine("Your marker has been set in space {0}, {1}!", r, c);
                Console.WriteLine();
                //DrawGrid();
                //Console.WriteLine();
                return true;
            } else {
                Console.WriteLine("The space at {0}, {1} is occupied! Please try again.", r, c);
                Console.WriteLine();
                return false;
            }
        }

        public bool CheckWin(Player player)
        {
            // 1. Check for all markers in a single row
            for (int i = 1; i < NumRows + 1; i++)
            {
                List<Cell> results = Cells.FindAll(objCell => +objCell.Row == i && objCell.Marker == player.Marker);
                if (results.Count == NumCols)
                {
                    return AnnounceWinner(player);
                }
            }

            // 2. Check for all markers in a single column
            for (int i = 1; i < NumCols + 1; i++)
            {
                List<Cell> results = Cells.FindAll(objCell => objCell.Column == i && objCell.Marker == player.Marker);
                if (results.Count == NumRows)
                {
                    return AnnounceWinner(player);
                }
            }

            // 3. Diagonal top left to bottom right
            List<Cell> diagResults = new List<Cell>();
            for (int i = 1; i < NumCols + 1; i++)
            {
                Cell objFound = Cells.Find(objCell => objCell.Row == i && objCell.Column == i && objCell.Marker == player.Marker);
                if (objFound != null)
                {
                    diagResults.Add(objFound);
                    if (diagResults.Count == NumCols)
                    {
                        return AnnounceWinner(player);
                    }
                }
            }
            diagResults.Clear();

            // 4. Diagonal top right to bottom left
            for (int i = 1; i < NumCols + 1; i++)
            {
                Cell objFound = Cells.Find(objCell => objCell.Row == i && objCell.Column == NumCols + 1 - i && objCell.Marker == player.Marker);
                if (objFound != null)
                {
                    diagResults.Add(objFound);
                    if (diagResults.Count == NumCols)
                    {
                        return AnnounceWinner(player);
                    }
                }
            }
            return false;
        }

        private bool AnnounceWinner(Player player)
        {
            Console.WriteLine("###################################");
            Console.WriteLine("YOU WON THE GAME! Congratulations, {0}!", player.Name);
            Console.WriteLine("###################################");
            return true;
        }
    }
}
