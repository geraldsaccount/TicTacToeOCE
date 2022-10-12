// Author: gérald
// Date: 12.10.2022

using System;
using System.IO;

namespace TicTacToeOCE {
    class GameLoop {
        private Grid grid;
        private Input input;
        private WinCheck winCheck;

        public GameLoop() {
            grid = new Grid(3);
            input = new Input(grid);
            winCheck = new WinCheck(grid, input);
        }
        
        public void Game() {
            bool isPlayerX = true;
            Grid.Space winner;
            do {
                grid.DrawGrid();
                input.PlayerInput(isPlayerX);
                isPlayerX = !isPlayerX;
            } while (!winCheck.GameEnd(out winner));
            
            grid.DrawGrid();
            Console.WriteLine($"The winner is {winner}");
        }
    }
}
