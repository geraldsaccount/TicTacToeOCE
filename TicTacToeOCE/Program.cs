using System;

namespace TicTacToeOCE {
    class Program {
        enum Space{ Empty, X, O }
        
        private static Space[,] grid;
        private const int GRID_SIZE = 3;
        private static int xCoord;
        private static int yCoord;
            
        static void Main(string[] args) {
            GameLoop();
        }

        private static void GameLoop() {
            grid = new Space[GRID_SIZE, GRID_SIZE];
            bool isPlayerX = true;
            Space winner = Space.Empty;
            do {
                DrawGrid();
                PlayerInput(isPlayerX);
                isPlayerX = !isPlayerX;
            } while (!GameEnd(out winner));
            
            DrawGrid();
            Console.WriteLine($"The winner is {winner}");
        }

        private static void DrawGrid() {
            Console.Clear();
            for (int y = 0; y < GRID_SIZE; y++) {
                if (y > 0) {
                    Console.WriteLine("------");
                }
                for (int x = 0; x < GRID_SIZE; x++) {
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

        private static void PlayerInput(bool isPlayerX) {
            bool valid;
            
            do {
                yCoord = GetAxisInput("line");
                xCoord = GetAxisInput("column");

                valid = grid[xCoord, yCoord] == Space.Empty;
            } while (!valid);

            if (isPlayerX) {
                grid[xCoord, yCoord] = Space.X;
            } else {
                grid[xCoord, yCoord] = Space.O;
            }
        }

        private static int GetAxisInput(string axisName) {
            bool valid = false;
            int axisInput;
            do {
                Console.WriteLine($"Please choose a {axisName} (1-3)");
                if (int.TryParse(Console.ReadLine(), out axisInput)) {
                    if (axisInput > 0 && axisInput <= GRID_SIZE) {
                        valid = true;
                    }
                }
            } while (!valid);
            return axisInput - 1;
        }

        private static bool GameEnd(out Space winner) {
            // check input line
            Space first = grid[0, yCoord];
            int sameCounter = 1;
            for (int x = 1; x < GRID_SIZE; x++) {
                Space current = grid[x, yCoord];
                if (first != current) {
                    break;
                }
                
                sameCounter++;
            }

            if (sameCounter == GRID_SIZE) {
                winner = grid[xCoord, yCoord];
                return true;
            }
            
            // check input column
            first = grid[xCoord, 0];
            sameCounter = 1;
            for (int y = 1; y < GRID_SIZE; y++) {
                Space current = grid[xCoord, y];
                if (first != current) {
                    break;
                }
                
                sameCounter++;
            }

            if (sameCounter == GRID_SIZE) {
                winner = grid[xCoord, yCoord];
                return true;
            }
            
            // check diagonals
            first = grid[0, 0];
            sameCounter = 1;
            for (int d = 1; d < GRID_SIZE; d++) {
                Space current = grid[d, d];
                if (current == Space.Empty || first != current) {
                    break;
                }
                
                sameCounter++;
            }
            
            if (sameCounter == GRID_SIZE) {
                winner = grid[xCoord, yCoord];
                return true;
            }

            first = grid[0, 2];
            sameCounter = 1;
            for (int d = 1; d < GRID_SIZE; d++) {
                Space current = grid[d, GRID_SIZE - 1 - d];
                if (current == Space.Empty || first != current) {
                    break;
                }
                
                sameCounter++;
            }
            
            if (sameCounter == GRID_SIZE) {
                winner = grid[xCoord, yCoord];
                return true;
            }

            bool hasEmpty = false;
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    if (grid[x, y] == Space.Empty) {
                        hasEmpty = true;
                        break;
                    }
                }

                if (hasEmpty) {
                    break;
                }
            }

            if (!hasEmpty) {
                winner = Space.Empty;
                return true;
            }
            
            winner = Space.Empty;
            return false;
        }
    }
}
