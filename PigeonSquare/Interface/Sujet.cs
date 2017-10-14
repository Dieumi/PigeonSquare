using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonSquare.Interface
{
    interface Sujet
    {
         void add(Pigeon p);
         void remove(Pigeon p);
         void notify();
    }
}
