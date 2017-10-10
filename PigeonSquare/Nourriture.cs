using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PigeonSquare
{
    public class Nourriture
    {
        public bool etat;
        public bool avarie;
        public double Y { get; set; }
        public double X { get; set; }
        private const int TIME_CONSERVE = 2000; //temps de conservation des cookies (ms)
        Timer timer = new Timer(TIME_CONSERVE);

        public Nourriture(double x, double y)
        {
            etat = true;
            avarie = false;
            X = x;
            Y = y;
            
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent) ;    
            timer.AutoReset = false;          
            timer.Enabled = true;  // Start the timer
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            avarie = true;
        }
    }
}
