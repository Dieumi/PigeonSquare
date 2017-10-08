using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare
{
    public class Human
    {
        public bool etat;
        public double Y { get; set; }
        public double X { get; set; }
        public Human(double x, double y)
        {
            etat = true;
            X = x;
            Y = y;
        }

        public void marcheAndDestroy()
        {
            if (Y <= 20)
            {
                Y++;
            }
            else
            {
               etat = false;
            }
        }

    }
}

