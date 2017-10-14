using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare.Strategie
{
    public class Fuite : StrategieAbstraite
    {
        public Fuite(string nom)
        {
            this.Nom = nom;
        }

        public override void Deplacement(int dimX, int dimY, Pigeon unPerso)
        {
            if (unPerso.Y > 0 && unPerso.Y < 20 && unPerso.X > 0 && unPerso.X < 20)   //empeche de sortir du cadre
            {
                if (unPerso.target2.X != unPerso.X)
                {
                    if (unPerso.target2.X > unPerso.X)
                    {
                        unPerso.X--;
                    }
                    else
                    {
                        unPerso.X++;
                    }
                }

                if (unPerso.target2.Y != unPerso.Y)
                {
                    if (unPerso.target2.Y > unPerso.Y)
                    {
                        unPerso.Y--;
                    }
                    else
                    {
                        unPerso.Y++;
                    }
                }
            }
        }
    }
}
