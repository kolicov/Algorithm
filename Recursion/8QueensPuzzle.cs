using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // * Description of the task *:
    // Write a program to find all possible placements of 8 chess queens on a chessboard, so that no two queens can attack each other (on a row, column or diagonal).
    public class ChessTable
    {
        // Chess table            X →                 0    1    2    3    4    5    6    7
        string[,] _chessTable = new string[,]{/*0*/{"| ","| ","| ","| ","| ","| ","| ","| "}, // Y
                                              /*1*/{"| ","| ","| ","| ","| ","| ","| ","| "}, // ↓
                                              /*2*/{"| ","| ","| ","| ","| ","| ","| ","| "},
                                              /*3*/{"| ","| ","| ","| ","| ","| ","| ","| "},
                                              /*4*/{"| ","| ","| ","| ","| ","| ","| ","| "},
                                              /*5*/{"| ","| ","| ","| ","| ","| ","| ","| "},
                                              /*6*/{"| ","| ","| ","| ","| ","| ","| ","| "},
                                              /*7*/{"| ","| ","| ","| ","| ","| ","| ","| "}};

        public const string QUEEN = "|*";
        public const string OUT_OF_TABLE = "0";
        public const string EMPTY = "| ";
        public const string UNDER_ATTACK = "|-";

        public const int RowsCount = 8;
        public const int ColumnsCount = 8;

        // int represents x and y. For example 24 is x=2 and y=4
        List<int> AttackedByQueensPlaces = new List<int>();

        int _queensOnTheTable = 0;

        public int QueensCombinations { get; private set; }

        public string this[int place]
        {
            get
            {
                int column, row;
                ConvertPlaceToColumnAndRow(place, out column, out row);

                if (column >= 0 && column < ColumnsCount && row >= 0 && row < RowsCount)
                {
                    return _chessTable[row, column];
                }
                else
                {
                    return OUT_OF_TABLE;
                }
            }
            set
            {
                int column, row;
                ConvertPlaceToColumnAndRow(place, out column, out row);

                if (column >= 0 && column < 8 && row >= 0 && row < 8)
                {
                    if (value != _chessTable[row, column])
                    {
                        _chessTable[row, column] = value;
                    }
                }
            }
        }

        public bool CanPlace(int place)
        {
            bool isPlaceFree = false;

            if (this[place] != OUT_OF_TABLE && !IsPlaceAttacked(place))
            {
                isPlaceFree = true;
            }

            return isPlaceFree;
        }

        public void PutQueenAtPlace(int place)
        {
            this[place] = QUEEN;

            var queenAttackPlaces = GetQueenAttackPlaces(place);

            AttackedByQueensPlaces.AddRange(queenAttackPlaces);

            // AttackedByQueensPlaces.Sort(); // For Debugging

            _queensOnTheTable++;

            if (_queensOnTheTable == 8)
            {
                QueensCombinations++;

                Print(false, true);
            }
        }

        public void RemoveQueenFromPlace(int place)
        {
            this[place] = EMPTY;

            var queenAttackPlaces = GetQueenAttackPlaces(place);

            foreach (int i in queenAttackPlaces)
            {
                AttackedByQueensPlaces.Remove(i);
            }

            // AttackedByQueensPlaces.Sort(); // For Debugging
            _queensOnTheTable--;
        }

        private bool IsPlaceAttacked(int place)
        {
            return AttackedByQueensPlaces.Contains(place);
        }

        public void Print(bool overwritePrevious, bool displayAttackedPlaces = false)
        {
            if (overwritePrevious)
            {
                Console.CursorTop = 0;
            }

            Console.Write(" ");
            for (int row = 0; row < 8; row++)
            {
                Console.Write(" " + row);
            }

            Console.WriteLine();

            for (int column = 0; column < 8; column++)
            {
                Console.WriteLine(column);
            }

            Console.WriteLine();

            if (overwritePrevious)
            {
                Console.CursorTop = 1;
            }
            else
            {
                Console.CursorTop = Console.CursorTop -= 9;
            }

            for (int row = 0; row < 8; row++)
            {
                Console.CursorLeft = 1;
                for (int column = 0; column < 8; column++)
                {
                    int place = ConvertColumnAndRowToPlace(column, row);

                    if (displayAttackedPlaces && AttackedByQueensPlaces.Contains(place) && this[place] != QUEEN)
                    {
                        Console.Write(UNDER_ATTACK);
                    }
                    else
                    {
                        Console.Write(this[place]);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void ConvertPlaceToColumnAndRow(int place, out int column, out int row)
        {
            column = place / 10;
            row = place % 10;
        }

        public static int ConvertColumnAndRowToPlace(int column, int row)
        {
            int place = column * 10 + row;

            return place;
        }

        private static List<int> GetQueenAttackPlaces(int queenPlace)
        {
            var places = new List<int>() { queenPlace };

            int column, row;
            ConvertPlaceToColumnAndRow(queenPlace, out column, out row);

            int vertical = column * 10;
            int horizontal = row;

            for (int i = 0; i < 8; i++, vertical += 1, horizontal += 10)
            {
                if (vertical != queenPlace)
                {
                    places.Add(vertical);
                }

                if (horizontal != queenPlace)
                {
                    places.Add(horizontal);
                }
            }

            // 11 or 9 is the difference between two places in a diagonal

            // Left diagonal
            places.AddRange(GetDiagonalPlaces(queenPlace, -11));  // places to the left
            places.AddRange(GetDiagonalPlaces(queenPlace, 11));  // places to the right

            // Right diagonal
            places.AddRange(GetDiagonalPlaces(queenPlace, -9));   // places to the left
            places.AddRange(GetDiagonalPlaces(queenPlace, 9));   // places to the right

            return places;
        }

        private static List<int> GetDiagonalPlaces(int place, int diff)
        {
            var numbers = new List<int>();

            int n = place;

            bool withinRange = true;

            while (withinRange)
            {
                n += diff;

                int column, row;
                ConvertPlaceToColumnAndRow(n, out column, out row);

                if ((column >= 0 && column <= 7) && (row >= 0 && row <= 7))
                {
                    numbers.Add(n);
                }
                else
                {
                    withinRange = false;
                }
            }

            return numbers;
        }
    }

    class _8QueensPuzzle
    {
        ChessTable _chessTable = new ChessTable();

        public void Run()
        {
            Move(0);

            Console.WriteLine("Total number of combinations: " + _chessTable.QueensCombinations);
        }

        private void Move(int row)
        {
            for (int column = 0; column < ChessTable.ColumnsCount; column++)
            {
                int place = ChessTable.ConvertColumnAndRowToPlace(column, row);

                if (_chessTable.CanPlace(place))
                {
                    _chessTable.PutQueenAtPlace(place);
                    // _chessTable.Print(true, true); // For Debugging

                    if (row + 1 < ChessTable.RowsCount)
                    {
                        Move(row + 1);
                    }

                    _chessTable.RemoveQueenFromPlace(place);
                    // _chessTable.Print(true, true); // For Debugging
                }
            }
        }
    }
}
