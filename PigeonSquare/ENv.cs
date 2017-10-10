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
        public int vitesse = 500; // vitesse d'exécution du thread
        const int  HUMAIN_APPARITION = 25;//probabilité d'apparaition de l'humain

        public List<Pigeon> listp = new List<Pigeon>();
        public List<Nourriture> listn = new List<Nourriture>();
        public List<Human> listh = new List<Human>();
        //Listes contenant les pigeons,les cookies et les humains
        public Env(int _dimensionX, int _dimensionY)
        {
            
            this.DimensionX = _dimensionX;
            this.DimensionY = _dimensionY;
            Thread t1 = new Thread(createPigeon);//pour chaque pigon créé, on créer un thread correspondant
            Thread t2 = new Thread(createPigeon);
            Thread t3 = new Thread(createPigeon);
            t1.Start();
            t2.Start();
            t3.Start();
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

            foreach(Human h in listh)
            {
                h.marcheAndDestroy();
            }
         
            if (Hazard.Next(1, 30) >= HUMAIN_APPARITION)
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
               // p.maj(listh);
            }
        }

    
    }
}
