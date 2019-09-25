﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut_WPF
{
    class LightsOutGame
    {
        private int gridSize = 3;
        private bool[,] grid;           // Store the on/off state of the grid        
        private Random rand;
        public const int MaxGridSize = 7;
        public const int MinGridSize = 3;

        // Returns the grid size
        public int GridSize
        {
            get {
                return gridSize;
            }
            set
            {
                if (value >= MinGridSize && value <= MaxGridSize)
                {
                    gridSize = value;
                    grid = new bool[gridSize, gridSize];
                    NewGame();
                }
            }
        }
        public LightsOutGame() {
            rand = new Random();
            GridSize = MinGridSize;
        }

        // Returns the grid value at the given row and column
        public bool GetGridValue(int row, int col)
        {
            return grid[row, col];
        }

        // Randomizes the grid
        public void NewGame()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    grid[r, c] = rand.Next(2) == 1;
                }
            }
        }

        // Inverts the selected box and all surrounding boxes
        public void Move(int row, int col)
        {
            if (row < 0 || row >= gridSize || col < 0 || col >= gridSize)
            {
                throw new ArgumentException("Row or column is outside the legal range of 0 to " + (gridSize - 1));
            }

            // Invert selected box and all surrounding boxes
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < gridSize && j >= 0 && j < gridSize)
                    {
                        grid[i, j] = !grid[i, j];
                    }
                }
            }

        }

        // Returns true if all cells are off
        public bool IsGameOver()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (grid[r, c])
                    {
                        return false;
                    }
                }
            }

            // All values must be false (off)
            return true;
        }
    }
}
