using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{   
    [Serializable]
    public class Score : IComparable<Score>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Score(string n, int s)
        {
            Name = n;
            Points = s;
        }

        public int CompareTo(Score other)
        {
            return other.Points - Points;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Points.ToString());
        }
    }
}
