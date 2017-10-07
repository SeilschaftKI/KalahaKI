using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    public class Result
    {
        private int KalahaSpieler1 { get; set; }
        private int KalahaSpieler2 { get; set; }
        private int Spieldauer { get; set; }

        public Result()
        {
            Spieldauer = 0;
        }

        public void NeuerZug()
        {
            Spieldauer++;
        }

    }
}
