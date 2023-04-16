using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

namespace cli_life
{
    class Program
    {
        static void Main(string[] args)
        {
            string solutionRootPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            Console.WriteLine(solutionRootPath);
            
            GameOfLife gameOfLife = JsonReader.ReadSettings($"{solutionRootPath}/Life/Settings.json");
            gameOfLife.Reset($"{solutionRootPath}/States/2023-04-12T13:57:54.txt");
            gameOfLife.Reset();
            
            for(int i = 0; i < gameOfLife.iterations; i++)
            {
                Console.Clear();
                gameOfLife.Render();
                if (i < gameOfLife.iterations - 1) gameOfLife.board.Advance();
                Thread.Sleep(gameOfLife.delay);
            }
            
            Print(gameOfLife);
            gameOfLife.board.Print();
            gameOfLife.board.ExportState($"{solutionRootPath}/States");

            void Print(GameOfLife g)
            {
                Console.WriteLine($"Board: {g.boardWidth} x {g.boardHeight};\nSymbols: {g.deadSymbol} / {g.liveSymbol};\nDelay: {g.delay}\nPath to patterns: {g.pathToPatterns}");
            }
        }
    }
}