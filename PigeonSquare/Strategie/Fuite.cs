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
            throw new NotImplementedException();
        }
    }
}
