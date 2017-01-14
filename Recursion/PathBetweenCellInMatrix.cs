using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // * Description of the task *:

    // We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two cells in the matrix. 
    // The matrix can be represented by a two-dimensional char array or a string array, passable cells are represented by a space (' '), 
    // non-passable cells are represented by asterisks ('*'), the start cell is represented by the symbol 's' and the exit cell is represented by 'e'. 
    // Movement is allowed in all four directions (up, down, left, right) and a cell can be passed only once in a given path.
    // Print on the console all paths and on the last line the count of paths found. 
    // You can represent the directions with symbols, e.g. 'D' for down, 'U' for up, etc. The ordering of the paths is not relevant.
    class PathBetweenCellInMatrix
    {
        List<string> _paths = new List<string>();

        //                            X → 
        char[,] Matrix = new char[,]{{'S',' ',' ',' ',' ',' '}, // Y
                                     {' ','*','*',' ','*',' '}, // ↓
                                     {' ','*','*',' ','*',' '},
                                     {' ','*','E',' ',' ',' '},
                                     {' ',' ',' ','*',' ',' '}};
        int X;
        int Y;

        public void Run()
        {
            // Matrix dimensions
            X = Matrix.GetLength(1);
            Y = Matrix.GetLength(0);

            // Move to start ('S')
            Move(0, 0, "", ' ');

            PrintPaths();
        }

        void Move(int x, int y, string path, char step)
        {
            if (step != ' ')
            {
                path += step;
            }

            char elem = ElemAt(x, y);

            if (elem == 'E')
            {
                _paths.Add(path);

                return;
            }
            else if (elem == ' ')
            {
                // Mark as visited
                Matrix[y, x] = 'V';
            }

            if (elem == ' ' || elem == 'S')
            {
                // Left
                char nextElem = ElemAt(x - 1, y);
                if (nextElem == ' ' || nextElem == 'E')
                {
                    Move(x - 1, y, path, '←');
                }

                // Top
                nextElem = ElemAt(x, y - 1);
                if (nextElem == ' ' || nextElem == 'E')
                {
                    Move(x, y - 1, path, '↑');
                }

                // Right
                nextElem = ElemAt(x + 1, y);
                if (nextElem == ' ' || nextElem == 'E')
                {
                    Move(x + 1, y, path, '→');
                }

                // Bottom
                nextElem = ElemAt(x, y + 1);
                if (nextElem == ' ' || nextElem == 'E')
                {
                    Move(x, y + 1, path, '↓');
                }
            }

            //PrintMatrix();

            if (Matrix[y, x] == 'V')
            {
                // Mark as visited
                Matrix[y, x] = ' ';
            }
        }

        private char ElemAt(int x, int y)
        {
            if ((x >= 0 && x < X) &&
               (y >= 0 && y < Y)) // Not outside the matrix
            {
                return Matrix[y, x];
            }

            return '0'; // Out of scope 
        }

        void PrintMatrix()
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    {
                        Console.Write(Matrix[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }

        void PrintPaths()
        {
            foreach (string path in _paths)
            {
                Console.WriteLine(path);
            }
        }
    }

}
