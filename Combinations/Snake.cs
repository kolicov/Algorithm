using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // * Description of the task *:

    // A snake is a sequence of several square blocks, attached one after another. A snake starts with a block at some position and 
    // continues with another block to the left, right, up or down, then again with another block to the left, right, up or down, etc. 
    // A snake of size N consists of a sequence of N blocks and is not allowed to cross itself.
    // You are given a number N and you should find all possible snakes of N blocks, represented as sequences of moves denoted as: 
    // S (start), L (move left), R (move right), U (move up) and D (move down). Examples (for N = 1, 2, 3, 4) 
    // Example for N = 4:
    // SRRR
    // SRRD
    // SRDR
    // SRDL
    // Snakes count = 4	
    // Note that there are many other correct outputs for N = 4, but this is the expected output according to the priority of directions (right, down, left, up).
    class Snake
    {
        // The matrix represents a field (square n x n), where 1 shows the snake part and 0 - the empty place.
        // The square field allows us to represent all variations of a snake with the length n (_snakeLength).
        // For example a snake with length 4:
        //    x ->
        // { {1, 1, 1, 1},    { {1, 1, 1, 0},   { {1, 1, 0, 0},   { {1, 1, 0, 0},   // Y 
        //   {0, 0, 0, 0},      {0, 0, 1, 0},     {1, 1, 0, 0},     {0, 1, 1, 0},   // ↓
        //   {0, 0, 0, 0},      {0, 0, 0, 0},     {0, 0, 0, 0},     {0, 0, 0, 0},
        //   {0, 0, 0, 0} }     {0, 0, 0, 0} }    {0, 0, 0, 0} }    {0, 0, 0, 0} }

        char[,] _matrix;

        List<string> _validSnakes = new List<string>();
        List<string> _validFormulas = new List<string>();

        int _snakeLength;
        int _duplicatedSnakes;

        // N <= 15
        const int MAX_SNAKE_LENGTH = 15;
        const char INVALID_PLACE = '-';
        const char VISITED_PLACE = '1';

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Added in order to display the arrows: '←', '↑', .etc

            Console.Write("Enter snake length: ");

            int snakeLength = Convert.ToInt32(Console.ReadLine());

            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (snakeLength > 0 && snakeLength <= MAX_SNAKE_LENGTH)
            {
                _snakeLength = snakeLength;

                InitMatrix();

                Move(0, 0, "", 'S');
            }
            else
            {
                Console.WriteLine("Enter a number between 1 and " + MAX_SNAKE_LENGTH);
            }

            watch.Stop();
            var elapsedTime = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalSeconds;

            Console.WriteLine("Snakes count: " + _validSnakes.Count());
            Console.WriteLine("Duplicated snakes: " + _duplicatedSnakes);
            Console.WriteLine("Time : " + elapsedTime + " seconds");
        }

        private void InitMatrix()
        {
            // Each snake can fit into a matrix having sides - length of a snake and length of a snake divided by 2.
            int width = _snakeLength;
            int height = _snakeLength / 2;

            if (_snakeLength % 2 > 0)
            {
                height++;
            }

            _matrix = new char[width, height];
        }

        void Move(int x, int y, string snake, char step)
        {
            if (x == 0 && y == 1)
            {
                return;
            }

            snake += step;

            // Mark as visited
            _matrix[x, y] = step;

            if (snake.Length == _snakeLength)
            {
                string formula;
                if (!ExistsSnake(snake, out formula))
                {
                    //int num = _validSnakes.Count + 1;
                    //Console.WriteLine("Snake: " + num);
                    PrintMatrix();
                    _validFormulas.Add(formula);
                    _validSnakes.Add(snake);
                }

                _duplicatedSnakes++;
            }

            if (snake.Length < _snakeLength)
            {
                // Left
                char nextElem = ElemAt(x - 1, y);
                if (nextElem == 0)
                {
                    Move(x - 1, y, snake, '←');
                }

                // Top
                nextElem = ElemAt(x, y - 1);
                if (nextElem == 0)
                {
                    Move(x, y - 1, snake, '↑');
                }

                // Right
                nextElem = ElemAt(x + 1, y);
                if (nextElem == 0)
                {
                    Move(x + 1, y, snake, '→');
                }

                // Bottom
                nextElem = ElemAt(x, y + 1);
                if (nextElem == 0)
                {
                    Move(x, y + 1, snake, '↓');
                }
            }

            FreeElement(x, y);
        }

        private void FreeElement(int x, int y)
        {
            // Remove visited status
            if (_matrix[x, y] != '\0' && _matrix[x, y] != 'N')
            {
                // Remove visited status
                _matrix[x, y] = '\0';
            }
        }

        private char ElemAt(int x, int y)
        {
            if ((x >= 0 && x < _matrix.GetLength(0)) &&
               (y >= 0 && y < _matrix.GetLength(1))) // Not outside the matrix
            {
                return _matrix[x, y];
            }

            return '-'; // Out of scope 
        }

        string ParseFormulaFromSnake(string snake)
        {
            string formula = "";

            int count = 0;

            snake = snake.Remove(0, 1);

            char last = snake[0];

            var formulaLetters = new Dictionary<char, char>();

            char letter = 'a';
            formulaLetters.Add(last, letter);

            Stack<char> letters = new Stack<char>();
            
            letters.Push('d');
            letters.Push('c');
            letters.Push('b');
            letters.Push('a');

            char let = letter;
            bool needNewAdd = false;

            for (int i = 0; i < snake.Length; i++)
            {
                char ch = snake[i];

                if (i == snake.Length - 1 || ch != last)
                {
                    if (ch == last)
                    {
                        count++;
                    }

                    if (i == snake.Length - 1 && ch != last)
                    {
                        needNewAdd = true;
                    }

                    formula += count + let.ToString();

                    if (!formulaLetters.TryGetValue(ch, out let))
                    {
                        letter++;
                        let = letter;
                        formulaLetters.Add(ch, let);
                    }

                    last = ch;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            if (needNewAdd)
            {
                formula += count + let.ToString();
            }

            return formula;
        }

        private bool ExistsSnake(string snake, out string s)
        {
            s = "";
            //string formula = ParseFormulaFromSnake(snake);

            //return _validFormulas.Contains(formula);

            foreach (string curSnake in _validSnakes)
            {
                if (AreSnakesEqual(curSnake, snake))
                {
                    return true;
                }
            }
            return false;
        }

        string RotateSnakeClockwise(string snake)
        {
            string rotatedSnake = "";

            foreach (char ch in snake)
            {
                switch (ch)
                {
                    case '←':
                        rotatedSnake += '↑';
                        break;
                    case '↑':
                        rotatedSnake += '→';
                        break;
                    case '→':
                        rotatedSnake += '↓';
                        break;
                    case '↓':
                        rotatedSnake += '←';
                        break;
                    default:
                        rotatedSnake += ch;
                        break;
                }
            }

            return rotatedSnake;
        }

        bool AreSnakesEqual(string snake1, string snake2)
        {
            bool equal = false;

            if (snake1.Equals(snake2) || RotateFlipAndCompare(snake1, snake2))
            {
                equal = true;
            }
            else
            {
                snake1 = ReverseSnake(snake1);

                if (snake1.Equals(snake2) || RotateFlipAndCompare(snake1, snake2))
                {
                    equal = true;
                }
            }

            return equal;
        }

        private bool RotateFlipAndCompare(string snake1, string snake2)
        {
            bool equal = false;

            // Check flipping in the four directions
            int i = 0;

            while (i < 4)
            {
                snake1 = RotateSnakeClockwise(snake1);

                if (snake1.Equals(snake2))
                {
                    equal = true;
                    break;
                }
                else
                {
                    string snake;
                    if (snake1[1] == '←' || snake1[1] == '→')
                    {
                        snake = FlipSnakeVertically(snake1);
                    }
                    else
                    {
                        snake = FlipSnakeHorizontally(snake1);
                    }

                    if (snake.Equals(snake2))
                    {
                        return true;
                    }
                }

                i++;
            }

            return equal;
        }

        private string ReverseSnake(string snake)
        {
            return ReverseString(snake, 1, snake.Length - 1);
        }

        private string FlipSnakeVertically(string snake)
        {
            string str = "";

            foreach (char ch in snake)
            {
                if (ch == '↑')
                {
                    str += '↓';
                }
                else if (ch == '↓')
                {
                    str += '↑';
                }
                else
                {
                    str += ch;
                }
            }

            return str;
        }

        private string FlipSnakeHorizontally(string snake)
        {
            string str = "";

            foreach (char ch in snake)
            {
                if (ch == '→')
                {
                    str += '←';
                }
                else if (ch == '←')
                {
                    str += '→';
                }
                else
                {
                    str += ch;
                }
            }

            return str;
        }

        /// <summary>
        /// Receives string and returns the string with its letters reversed.
        /// </summary>
        private static string ReverseString(string str, int index, int length)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr, index, length);
            return new string(arr);
        }

        void PrintMatrix()
        {
            //Console.CursorTop = 0;

            for (int y = 0; y < _matrix.GetLength(1); y++)
            {
                for (int x = 0; x < _matrix.GetLength(0); x++)
                {
                    char ch = _matrix[x, y];
                    if (ch == 0)
                    {
                        ch = '0';
                    }

                    Console.Write(ch);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
