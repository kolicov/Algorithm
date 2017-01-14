using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class TowerOfHanoi
    {
        int _towerHeight = 4;

        Stack<int> Source = new Stack<int>();
        Stack<int> Destination = new Stack<int>();
        Stack<int> Spare = new Stack<int>();

        int _numberOfMoves = 0;

        public TowerOfHanoi()
        {
            Source = new Stack<int>(Enumerable.Range(1, _towerHeight).Reverse());
        }

        public void Run()
        {
            MoveDisk(_towerHeight, Source, Destination, Spare);
        }

        private void DisplayCurrentState()
        {
            Console.WriteLine('\n' + "Move: " + ++_numberOfMoves);
            DisplayRod(Source, "Source", 0);
            DisplayRod(Destination, "Dest", 1);
            DisplayRod(Spare, "Spare", 2);

            int n = _towerHeight + 1;

            while (n-- != 0)
                Console.Write("\n");
        }

        private void DisplayRod(IEnumerable<int> rod, string rodName, int columnPos)
        {
            columnPos *= 10;
            int top = Console.CursorTop;

            Console.CursorTop = top;

            Console.CursorLeft = columnPos + 1;
            Console.Write(rodName);

            Console.CursorTop += _towerHeight;

            var reversedRod = new Stack<int>(new Stack<int>(rod.Reverse()));

            foreach (var disk in reversedRod)
            {
                Console.CursorLeft = columnPos + 1;
                Console.Write(disk);
                Console.CursorTop--;
            }

            Console.CursorTop = top;
        }

        private void MoveDisk(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (Destination.Count == _towerHeight || _numberOfMoves == 7)
            {
                // Stop reqursion. Task is solved!
                return;
            }

            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                DisplayCurrentState();

            }
            else
            {
                // Move disks on top of bottomDisk from Source to Spare
                MoveDisk(bottomDisk - 1, source, spare, destination);

                destination.Push(source.Pop());

                DisplayCurrentState();

                // Move disks previously moved to Spare to Destination
                MoveDisk(bottomDisk - 1, spare, destination, source);
            }
        }
    }
}
