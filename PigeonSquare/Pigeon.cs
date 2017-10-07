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
        public StrategieAbstraite StrategieCourante;
        public Nourriture target;
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
        /* public Nourriture closest(Nourriture n1,Nourriture n2)
         {


         }*/
        public void maj(List<Nourriture> listn)
        {
            if (target == null)
            {
                foreach(Nourriture n in listn)
                {
                    if (n.etat != false)
                    {
                        StrategieCourante = new Faim("faim");
                        target = n;
                        break;
                    }
                    
                };
            }else if (target.etat == false)
            {
                StrategieCourante = new Immobile("Immobile");
                target = null;
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
