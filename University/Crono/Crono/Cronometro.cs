using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Crono
{
    internal class Cronometro
    {
        private Timer Tiempo { get; set; }
        public Double Result { get; set; }

        public Cronometro()
        {
            Tiempo.Tick += new EventHandler(Tiempo_Tick);
            Tiempo.Interval = 100;
        }

        void Tiempo_Tick(object sender, EventArgs e)
        {
            Result++;
            //cada tick representa 100 milisegundos
        }

        public void Start()
        {
            Tiempo.Start();
        }

        public void Pause()
        {
            //
        }

        public void Stop()
        {
            Tiempo.Stop();
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0} ms",
                Result);

        }
    }
}
