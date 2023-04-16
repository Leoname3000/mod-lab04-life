using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace cli_life
{
    public class GameOfLife
    {
        public int boardWidth { get; set; }
        public int boardHeight { get; set; }
        //public int cellSize { get; set; }
        public double liveDensity { get; set; }
        public string liveSymbol { get; set; }
        public string deadSymbol { get; set; }
        public int iterations { get; set; }
        public int delay { get; set; }
        public string pathToPatterns { get; set; }
        
        public Board board { get; set; }
        
        public void Reset(string pathToState = null)
        {
            board = new Board(
                width: boardWidth,
                height: boardHeight,
                //cellSize: cellSize,
                liveDensity: liveDensity,
                pathToState: pathToState);
        }
        
        public void Render()
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Columns; col++)
                {
                    var cell = board.Cells[col, row];
                    if (cell.IsAlive)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.Write('\n');
            }
        }

        //public void Iterate()
        //{
        //    Console.Clear();
        //    Render();
        //    board.Advance();
        //    Thread.Sleep(delay);
        //}

        public Dictionary<Pattern, int> Statistics(string pathToPatternsFolder)
        {
            Dictionary<Pattern, int> statistics = new Dictionary<Pattern, int>();
            foreach (string file in Directory.EnumerateFiles(pathToPatternsFolder, "*.json"))
            {
                string rawPattern = File.ReadAllText(file);
                Pattern pattern = JsonSerializer.Deserialize<Pattern>(rawPattern);
                statistics.Add(pattern, 0);
            }
            return statistics;
        }
    }
}