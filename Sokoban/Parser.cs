﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Parser
    { 
        public Parser()
        {

        }
        public List<List<char>> GetLevel(int level)
        {
            List<List<char>> levelLayout = new List<List<char>>();
            string[] allLevelRows = System.IO.File.ReadAllLines(@"C:\Users\Public\Doolhof\doolhof"+ level +".txt");
            for (int i = 0; i < allLevelRows.Length; i++)
            {
                levelLayout.Add(new List<char>());
                char[] SplittedString = allLevelRows[i].ToCharArray();
                for (int j = 0; j < SplittedString.Length ; j++)
                {
                    levelLayout[i].Add(SplittedString[j]);
                }
            }
            return levelLayout;
        }

    }
}