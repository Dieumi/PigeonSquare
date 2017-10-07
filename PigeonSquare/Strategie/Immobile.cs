using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare.Strategie
{
    public class Immobile : StrategieAbstraite
    {
        public Immobile(string nom)
        {
            this.Nom = nom;
        }

        public override void Deplacement(int dimX, int dimY, Pigeon unPerso)
        {
           
        }
    }
}
