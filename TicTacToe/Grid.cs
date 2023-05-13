using nsPlayer;
using nsCell;

namespace nsGrid
{
    public class Grid
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }

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
                    Cell oFound = Cells.Find(oCell => oCell.Row == r && oCell.Column == c);
                    if (oFound != null)
                    {
                        Console.Write(" {0} ", oFound.Marker);
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
}
