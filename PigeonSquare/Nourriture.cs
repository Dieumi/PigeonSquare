using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare
{
    public class Nourriture
    {
        bool etat;
        public double Y { get; set; }
        public double X { get; set; }
        public Nourriture(double x, double y)
        {
            etat = true;
            X = x;
            Y = y;
        }
            
        
    }
}
