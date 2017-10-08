using PigeonSquare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PigeonSquare
{
    public class Env : Sujet
    {
        public static Random Hazard = new Random();
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int vitesse = 500;
        
        public List<Pigeon> listp = new List<Pigeon>();
        public List<Nourriture> listn = new List<Nourriture>();
        public List<Human> listh = new List<Human>();
        public Env(int _dimensionX, int _dimensionY)
        {
            
            this.DimensionX = _dimensionX;
            this.DimensionY = _dimensionY;
            Thread t1 = new Thread(createPigeon);
            Thread t2 = new Thread(createPigeon);
            Thread t3 = new Thread(createPigeon);
            t1.Start();
            t2.Start();
            t3.Start();
            /* Pigeon p1 = new Pigeon("p1");
             Pigeon p2 = new Pigeon("p2");
             Pigeon p3 = new Pigeon("p3");
             listp.Add(p1);
             listp.Add(p2);
             listp.Add(p3);*/

        }
        public void createPigeon()
        {
            Pigeon p1 = new Pigeon("p"+listp.Count);
            listp.Add(p1);
        }
        public void TourSuivant()
        {
            foreach(Pigeon p in listp)
            {
                p.Avance1Tour(p.X, p.Y);
            }
         
            if (Hazard.Next(1, 11) >= 10)
            {
               HumainPassage();
            }
            


        }

        private void HumainPassage()
        {
            Human h1 = new Human(Hazard.Next(0,20), Hazard.Next(0,20));
            listh.Add(h1);
            Console.WriteLine("ligne : "+h1.X+" colonne : "+h1.Y);
        }

        public void Avance()
        {
            while (true)
            {
                Thread.Sleep(vitesse);
                TourSuivant();
            }


        }

        public void add(Pigeon p)
        {
            listp.Add(p);
        }

        public void remove(Pigeon p)
        {
            listp.Remove(p);
        }

        public void notify()
        {
            foreach(Pigeon p in listp)
            {
                p.maj(listn);
                p.maj(listh);
            }
        }

    
    }
}
