using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PigeonSquare
{
   public class Pigeon 
    {
        public static Random Hazard = new Random();
        Thread thread;
        public int X { get; set; }
        public int Y { get; set; }
        public Pigeon()
        {
            X = Hazard.Next(1, 20);
            Y = Hazard.Next(1, 20);
            thread = new Thread(new ThreadStart(this.RunThread));
        }
        public void RunThread()
        {
            
        }
    }
}
