// Author: gérald
// Date: 12.10.2022

namespace TicTacToeOCE {
    public class WinCheck {
        private Grid grid;
        private Input input;

        public WinCheck(Grid grid, Input input) {
            this.grid = grid;
            this.input = input;
        }
        
        public bool GameEnd(out Grid.Space winner) {
            if (CheckVertical(out winner)) return true;
            if (CheckHorizontal(ref winner)) return true;
            if (CheckDiagonals(ref winner)) return true;
            if (CheckDraw(ref winner)) return true;

            winner = Grid.Space.Empty;
            return false;
        }

        private bool CheckDraw(ref Grid.Space winner) {
            bool hasEmpty = false;
            for (int y = 0; y < grid.Size; y++) {
                for (int x = 0; x < grid.Size; x++) {
                    if (grid.GetSpace(x, y) == Grid.Space.Empty) {
                        hasEmpty = true;

                        break;
                    }
                }

                if (hasEmpty) {
                    break;
                }
            }

            if (!hasEmpty) {
                winner = Grid.Space.Empty;

                return true;
            }

            return false;
        }

        private bool CheckDiagonals(ref Grid.Space winner) {
            int yCoord = input.YCoord;
            int xCoord = input.XCoord;
            Grid.Space first;
            int sameCounter;
            first = grid.GetSpace(0, 0);
            sameCounter = 1;
            for (int d = 1; d < grid.Size; d++) {
                Grid.Space current = grid.GetSpace(d, d);
                if (current == Grid.Space.Empty || first != current) {
                    break;
                }

                sameCounter++;
            }

            if (sameCounter == grid.Size) {
                winner = grid.GetSpace(xCoord, yCoord);

                return true;
            }

            first = grid.GetSpace(0, grid.Size - 1);
            sameCounter = 1;
            for (int d = 1; d < grid.Size; d++) {
                Grid.Space current = grid.GetSpace(d, grid.Size - 1 - d);
                if (current == Grid.Space.Empty || first != current) {
                    break;
                }

                sameCounter++;
            }

            if (sameCounter == grid.Size) {
                winner = grid.GetSpace(xCoord, yCoord);

                return true;
            }

            return false;
        }

        private bool CheckHorizontal(ref Grid.Space winner) {
            int yCoord = input.YCoord;
            int xCoord = input.XCoord;
            Grid.Space first;
            int sameCounter;

            // check input column
            first = grid.GetSpace(xCoord, 0);
            sameCounter = 1;
            for (int y = 1; y < grid.Size; y++) {
                Grid.Space current = grid.GetSpace(xCoord, y);
                if (first != current) {
                    break;
                }

                sameCounter++;
            }

            if (sameCounter == grid.Size) {
                winner = grid.GetSpace(xCoord, yCoord);

                return true;
            }

            return false;
        }

        private bool CheckVertical(out Grid.Space winner) { // check input line
            int yCoord = input.YCoord;
            int xCoord = input.XCoord;
            
            Grid.Space first = grid.GetSpace(0, yCoord);
            int sameCounter = 1;
            for (int x = 1; x < grid.Size; x++) {
                Grid.Space current = grid.GetSpace(x, yCoord);
                if (first != current) {
                    break;
                }

                sameCounter++;
            }

            if (sameCounter == grid.Size) {
                winner = grid.GetSpace(xCoord, yCoord);

                return true;
            }

            winner = Grid.Space.Empty;
            return false;
        }
    }
}
