// Author: gérald
// Date: 12.10.2022

using System;

namespace TicTacToeOCE {
    public class Grid {
        public enum Space{ Empty, X, O }
        
        private Space[,] grid;
        private int size;

        public int Size {
            get {
                return size;
            }
        }

        public Grid(int size) {
            this.size = size;
            grid = new Space[size, size];
        }
        
        public void DrawGrid() {
            Console.Clear();
            for (int y = 0; y < size; y++) {
                if (y > 0) {
                    Console.WriteLine("------");
                }
                for (int x = 0; x < size; x++) {
                    if (x > 0) {
                        Console.Write("|");
                    }
                    Space current = grid[x, y];
                    switch (current) {
                        case Space.Empty:
                            Console.Write(" ");
                            break;
                        case Space.X:
                            Console.Write("X");
                            break;
                        case Space.O:
                            Console.Write("O");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void SetSpace(int x, int y, Space value) {
            grid[x, y] = value;
        }

        public Space GetSpace(int x, int y) {
            return grid[x, y];
        }
    }
}
