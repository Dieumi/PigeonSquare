using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare.Strategie
{
    public class Faim : StrategieAbstraite
    {
        public Faim( string nom)
        {
            this.Nom = nom;
        }

        public override void Deplacement(int dimX, int dimY, Pigeon unPerso)
        {
            if(unPerso.target.X != unPerso.X )
            {
                if(unPerso.target.X > unPerso.X)
                {
                    unPerso.X += 1;
                }
                else 
                {
                    unPerso.X -= 1;
                }
            }else if (unPerso.target.Y != unPerso.Y)
            {
                if (unPerso.target.Y > unPerso.Y)
                {
                    unPerso.Y += 1;
                }
                else
                {
                    unPerso.Y -= 1;
                }
            }
            else
            {
                unPerso.mange();
            }

           
        }
    }
}
