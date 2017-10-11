using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    class Hand
    {
        public int Value { get; set; }
        public Field HoverOver { get; set; }

        public Hand()
        {
            Value = 0;
        }

        public void drop()
        {
            Value--;
            HoverOver.Fill();
            Console.WriteLine("Droppt in Feld {0} von {1}", HoverOver.Position, HoverOver.Owner);
        }

        public void DropAll()
        {
            while (Value > 0)
            {
                HoverOver.Fill();
            }
        }

        public void Take()
        {
            Value = HoverOver.Empty();
            Console.WriteLine("Nimmt aus Feld {0} von {1}", HoverOver.Position, HoverOver.Owner);
        }

        public void MoveToNext()
        {
            HoverOver = HoverOver.Follower;
            Console.WriteLine("Rückt weiter zu Feld {0} von {1}", HoverOver.Position, HoverOver.Owner);
        }

        public void MoveTo(Field field)
        {
            HoverOver = field;
            Console.WriteLine("Springt zu Feld {0} von {1}", HoverOver.Position, HoverOver.Owner);
        }
    }
}
