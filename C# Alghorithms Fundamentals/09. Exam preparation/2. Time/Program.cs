﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Time
{
    internal class Program
    {
        static int[][] table;
        static Stack<int> longest = new Stack<int>();
        static void Main(string[] args)
        {
            int[] firstSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InitTable(firstSequence, secondSequence);
            int row = firstSequence.Length;
            int col = secondSequence.Length;

            while (row > 0 && col > 0)
            {
                if (firstSequence[row - 1] == secondSequence[col - 1])
                {
                    longest.Push(firstSequence[row - 1]);
                    row--;
                    col--;
                }
                else if (table[row][col - 1] >= table[row - 1][col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }

            Console.WriteLine(String.Join(" ", longest));
            Console.WriteLine(longest.Count);
        }

        static void InitTable(int[] first, int[] second)
        {
            table = new int[first.Length + 1][];
            for (int row = 0; row < table.Length; row++)
            {
                table[row] = new int[second.Length + 1];
            }

            for (int row = 1; row < table.Length; row++)
            {
                for (int col = 1; col < table[row].Length; col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        table[row][col] = table[row - 1][col - 1] + 1;
                    }
                    else
                    {
                        table[row][col] = Math.Max(table[row][col - 1], table[row - 1][col]);
                    }
                }
            }
        }
    }
}
