using System;
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

        public bool IsTopTen(Score s)
        {
            if (scores.Count < 10)
                return true;

            if (scores[9].Points < s.Points)
                return true;
            
            return false;
        }

        public void AddHighScore(Score s)
        {
            scores.Add(s);
            scores.Sort();
        }
    }
}
