﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    [Serializable]
    public class HighScore
    {
        public List<Score> scores { get; set; }

        public HighScore()
        {
            scores = new List<Score>();
        }

        public bool IsTopTen(int s)
        {
            if (scores.Count < 10)
                return true;

            if (scores[9].Points < s)
                return true;
            
            return false;
        }

        public void AddHighScore(Score s)
        {
            scores.Add(s);
            scores.Sort();
            if (scores.Count > 10)
                scores.RemoveAt(10);
        }
    }
}
