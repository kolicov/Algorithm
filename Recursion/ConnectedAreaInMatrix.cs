using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Let’s define a connected area in a matrix as an area of cells in which there is a path between every two cells. 
    // Write a program to find all connected areas in a matrix. On the console, print the total number of areas found, 
    // and on a separate line some info about each of the areas – its position (top-left corner) and size. 
    // Order the areas by size (in descending order) so that the largest area is printed first.
    // If several areas have the same size, order them by their position, first by the row, then by the column of the top-left corner. 
    // So, if there are two connected areas with the same size, the one which is above and/or to the left of the other will be printed first.

    class Area : IComparable
    {
        public int Size;
        public int TopLeftCellX = -1;
        public int TopLeftCellY = -1;

        public int CompareTo(object obj)
        {
            int i = 0; // same

            return i;
        }

        public void PrintToConsole()
        {
            Console.Write("(" + TopLeftCellX.ToString() + ", " + TopLeftCellY.ToString() + "), size: " + Size.ToString() + "");
        }
    };

    class ConnectedAreaInMatrix
    {
        List<Area> Areas = new List<Area>();

        //                            X → 
        //char[,] Matrix = new char[,]{{' ',' ',' ','*',' ',' ',' ','*',' '}, // Y
        //                             {' ',' ',' ','*',' ',' ',' ','*',' '}, // ↓
        //                             {' ',' ',' ','*',' ',' ',' ','*',' '},
        //                             {' ',' ',' ',' ','*',' ','*',' ',' '}};

        //                            X → 
        char[,] Matrix = new char[,]{{'*',' ',' ','*',' ',' ',' ','*',' ',' '}, // Y
                                     {'*',' ',' ','*',' ',' ',' ','*',' ',' '}, // ↓
                                     {'*',' ',' ','*','*','*','*','*',' ',' '},
                                     {'*',' ',' ','*',' ',' ',' ','*',' ',' '},
                                     {'*',' ',' ','*',' ',' ',' ','*',' ',' '}};

        Area _currentArea;

        int MatrixX;
        int MatrixY;

        public void Run()
        {
            // Matrix dimensions
            MatrixX = Matrix.GetLength(1);
            MatrixY = Matrix.GetLength(0);

            _currentArea = new Area();

            Move(0, 0, 0);

            PrintAreas();
        }

        void Move(int x, int y, int reqursionDepth)
        {
            char elem = ElemAt(x, y);

            if (elem == ' ')
            {
                if (x < _currentArea.TopLeftCellX || _currentArea.TopLeftCellX == -1)
                {
                    _currentArea.TopLeftCellX = x;
                }

                if (y < _currentArea.TopLeftCellY || _currentArea.TopLeftCellY == -1)
                {
                    _currentArea.TopLeftCellY = y;
                }

                _currentArea.Size++;

                // Mark as visited
                Matrix[y, x] = Areas.Count().ToString()[0];
            }

            //PrintMatrix(); // For Debug needs. On each move we see the visited cell.

            // Left
            char nextElem = ElemAt(x - 1, y);
            if (nextElem == ' ')
            {
                Move(x - 1, y, reqursionDepth + 1);
            }

            // Top
            nextElem = ElemAt(x, y - 1);
            if (nextElem == ' ')
            {
                Move(x, y - 1, reqursionDepth + 1);
            }

            // Right
            nextElem = ElemAt(x + 1, y);
            if (nextElem == ' ')
            {
                Move(x + 1, y, reqursionDepth + 1);
            }

            // Bottom
            nextElem = ElemAt(x, y + 1);
            if (nextElem == ' ')
            {
                Move(x, y + 1, reqursionDepth + 1);
            }

            if (reqursionDepth == 0)
            {
                // The current area should have been revealed
                if (_currentArea.Size > 0)
                {
                    Areas.Add(_currentArea);
                }

                int nextAreaX;
                int nextAreaY;
                if (FindFirstNotVisitedTraversableCell(_currentArea.TopLeftCellX, _currentArea.TopLeftCellY, 0, out nextAreaX, out nextAreaY))
                {
                    _currentArea = new Area();
                    _currentArea.TopLeftCellX = nextAreaX;
                    _currentArea.TopLeftCellY = nextAreaY;

                    Move(nextAreaX, nextAreaY, 0);
                }
            }
        }

        private bool FindFirstNotVisitedTraversableCell(int x, int y, int visitedCells, out int foundX, out int foundY)
        {
            bool found = false;

            foundX = 0;
            foundY = 0;

            char elem = ElemAt(x, y);

            if (elem == ' ')
            {
                foundX = x;
                foundY = y;

                return true;
            }
            else
            {
                Matrix[y, x] = '.';
                visitedCells++;
            }

            //PrintMatrix(); // For Debug needs. On each move we see the visited cell.

            if (visitedCells < MatrixX * MatrixY)
            {
                // Left
                char nextElem = ElemAt(x - 1, y);
                if (nextElem != '-' && nextElem != '.')
                {
                    found = FindFirstNotVisitedTraversableCell(x - 1, y, visitedCells, out foundX, out foundY);
                }

                if (!found)
                {
                    // Top
                    nextElem = ElemAt(x, y - 1);
                    if (nextElem != '-' && nextElem != '.')
                    {
                        found = FindFirstNotVisitedTraversableCell(x, y - 1, visitedCells, out foundX, out foundY);
                    }
                }

                if (!found)
                {
                    // Right
                    nextElem = ElemAt(x + 1, y);
                    if (nextElem != '-' && nextElem != '.')
                    {
                        found = FindFirstNotVisitedTraversableCell(x + 1, y, visitedCells, out foundX, out foundY);
                    }
                }

                if (!found)
                {
                    // Bottom
                    nextElem = ElemAt(x, y + 1);
                    if (nextElem != '-' && nextElem != '.')
                    {
                        found = FindFirstNotVisitedTraversableCell(x, y + 1, visitedCells, out foundX, out foundY);
                    }
                }
            }

            return found;
        }

        private char ElemAt(int x, int y)
        {
            if ((x >= 0 && x < MatrixX) &&
               (y >= 0 && y < MatrixY)) // Not outside the matrix
            {
                return Matrix[y, x];
            }

            return '-'; // Out of Matrix 
        }

        void PrintAreas()
        {
            // Sort
            Console.Write("Total areas found: ");
            Console.Write(Areas.Count);
            Console.WriteLine();

            int i = 0;
            foreach (var area in Areas)
            {
                Console.Write("Area #" + i + " at ");
                area.PrintToConsole();
                Console.WriteLine();
                i++;
            }

            Console.WriteLine();
        }

        void PrintMatrix()
        {
            Console.CursorTop = 0;
            Console.WriteLine("Matrix: ");

            for (int y = 0; y < MatrixY; y++)
            {
                for (int x = 0; x < MatrixX; x++)
                {
                    Console.Write(Matrix[y, x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

}
