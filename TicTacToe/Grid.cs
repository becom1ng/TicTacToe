using nsPlayer;
using nsCell;

namespace nsGrid
{
    public class Grid
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }

        public List<Cell> Cells { get; private set; }

        /*public Grid(int rows, int cols)
        {
            CreateGrid(rows, cols);
            NumRows = rows;
            NumCols = cols;
        }*/

        public void CreateGrid(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            Cells = new List<Cell>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Cells.Add(new Cell(r, c));
                }
            }
        }

        public void DrawGrid()
        {
            for (int r = 0; r < NumRows; r++)
            {
                for (int c = 0; c < NumCols; c++)
                {
                    Cell objFound = Cells.Find(objCell => objCell.Row == r && objCell.Column == c);
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

        public bool MakeMove(Player player, int r, int c)
        {
            Cell objFound = Cells.Find(objCell => objCell.Row == r - 1  && objCell.Column == c - 1 && objCell.Marker == ' ');
            if (objFound != null) // Cell is blank
            {
                objFound.Marker = player.Marker;
                Console.WriteLine("Your marker has been set in space {0}, {1}!", r, c);
                Console.WriteLine();
                return false;
            } else {
                Console.WriteLine("The space at {0}, {1} is occupied! Please try again.", r, c);
                Console.WriteLine();
                return true;
            }
        }
    }
}
