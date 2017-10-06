using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PigeonSquare
{
    public class Env
    {
        public static Random Hazard = new Random();
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int vitesse = 500;
        public List<Pigeon> listp = new List<Pigeon>();
        public List<Nourriture> listn = new List<Nourriture>();
        public Env(int _dimensionX, int _dimensionY)
        {
            
            this.DimensionX = _dimensionX;
            this.DimensionY = _dimensionY;
            Pigeon p1 = new Pigeon();
            Pigeon p2 = new Pigeon();
            Pigeon p3 = new Pigeon();
            listp.Add(p1);
            listp.Add(p2);
            listp.Add(p3);

        }
        public void TourSuivant()
        {

            if (Hazard.Next(1, 11) >= 5)
            {
               //HumainPassage();
            }
            


        }
       
        public void Avance()
        {
            /*while (true)
            {
                Thread.Sleep(vitesse);
                TourSuivant();
            }*/


        }
    }
}
