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
        public int vitesse = 1200; // vitesse d'exécution du thread
        public int i = 0;
        const int  HUMAIN_APPARITION = 5;//probabilité d'apparaition de l'humain en pourcentage %

        public List<Pigeon> listp = new List<Pigeon>();
        public List<Nourriture> listn = new List<Nourriture>();
        public List<Human> listh = new List<Human>();
        //Listes contenant les pigeons,les cookies et les humains
        public Env(int _dimensionX, int _dimensionY)
        {
            
            this.DimensionX = _dimensionX;
            this.DimensionY = _dimensionY;
            Thread t1 = new Thread(createPigeon);//pour chaque pigon créé, on créer un thread correspondant
            t1.Start();
            Thread t2 = new Thread(createPigeon);
            t2.Start();
            Thread t3 = new Thread(createPigeon);
            t3.Start();
        }
        public void createPigeon()
        {
            i++;
            Pigeon p1 = new Pigeon("p" + i);
            listp.Add(p1);
        }
        public void TourSuivant()
        {
            foreach(Pigeon p in listp)
            {
                p.Avance1Tour(p.X, p.Y);
            }

            foreach(Human h in listh)
            {
                h.marcheAndDestroy();
            }
         
            if (Hazard.Next(1, 100) <= HUMAIN_APPARITION)
            {
               HumainPassage();
            }
            


        }

        private void HumainPassage()
        {
            Human h1 = new Human(Hazard.Next(0,20), Hazard.Next(0,20));
            listh.Add(h1);
            notify();
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
                //p.Detection(listh);
                p.maj(listn);
                p.maj(listh);
            }
        }

    
    }
}
