// Author: gérald
// Date: 12.10.2022

using System;

namespace TicTacToeOCE {
    public class Input {
        private Grid grid;
        
        public int XCoord { get; private set; }
        public int YCoord { get; private set; }

        public Input(Grid grid) {
            this.grid = grid;
        }
        
        public void PlayerInput(bool isPlayerX) {
            bool valid;
            int xCoord, yCoord;
            
            do {
                yCoord = GetAxisInput("line");
                xCoord = GetAxisInput("column");

                valid = grid.GetSpace(xCoord, yCoord) == Grid.Space.Empty;
            } while (!valid);

            XCoord = xCoord;
            YCoord = yCoord;

            if (isPlayerX) {
                grid.SetSpace(xCoord, yCoord, Grid.Space.X); 
            } else {
                grid.SetSpace(xCoord, yCoord, Grid.Space.O);
            }
        }


        private int GetAxisInput(string axisName) {
            bool valid = false;
            int axisInput;
            do {
                Console.WriteLine($"Please choose a {axisName} (1-3)");
                if (int.TryParse(Console.ReadLine(), out axisInput)) {
                    if (axisInput > 0 && axisInput <= grid.Size) {
                        valid = true;
                    }
                }
            } while (!valid);
            return axisInput - 1;
        }
    }
}
