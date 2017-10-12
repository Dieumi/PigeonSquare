using PigeonSquare.Interface;
using PigeonSquare.Strategie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PigeonSquare
{
   public class Pigeon : Observateur
    {

    
        public static Random Hazard = new Random();
       
        public string nom;
        public int X { get; set; }
        public int Y { get; set; }
        public bool detecte;
        public StrategieAbstraite StrategieCourante;
        public Nourriture target;
        public Human target2;

        public const int RANGE = 2;
        public Pigeon(string nom)
        {
            this.nom = nom;
            StrategieCourante = new Immobile("immobile");
            X = Hazard.Next(1, 20);
            Y = Hazard.Next(1, 20);
            //thread = new Thread(new ThreadStart(this.RunThread));
        }
        
        public void Avance1Tour(int dimX, int dimY)
        {
            this.StrategieCourante.Deplacement(dimX, dimY,this); 
        }
        /* public  void Nourriture closest(Nourriture n1,Nourriture n2)
         {


         }
         */

        public void Detection(List<Human> listh)
        {
            foreach (Human h in listh)
            {
                if (Math.Abs(h.X - X) <= RANGE || Math.Abs(h.X + X) <= RANGE || Math.Abs(h.Y-Y) <= RANGE || Math.Abs(h.Y+Y) <= RANGE)
                {
                    detecte = true;
                }
                else
                {
                    detecte = false;
                }
            }
        }



        public void maj(List<Nourriture> listn)
        {
            foreach (Nourriture n in listn)
            {
                if (n.etat == true && n.avarie == false)
                {
                    StrategieCourante = new Faim("Faim");
                    target = n;
                    break;
                }
                else if (n.etat== false || n.avarie == true)
                {
                    StrategieCourante = new Immobile("Immobile");
                    target = null;
                }
            }
        }


        public void maj(List<Human> listh)//tant que des hulains sont présent, les mouvement sont impossible
        {

                foreach (Human h in listh)
                {
                    if (h.etat != false)
                    {
                        if (detecte)
                        {
                            StrategieCourante = new Fuite("fuite");
                            target2 = h;
                            break;
                        }
                        else
                        {
                            StrategieCourante = new Immobile("Immobile");
                            target2 = null;
                            break;
                        }
                    }
                }
          
            
        }

        public void mange()
        {
            if (target.etat == true)
            {
                target.etat = false;
                Console.WriteLine(this.nom + " a mangé");
            }
           
            
        }
    }
}
