using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    class Field
    {
        public int Value { get; set; }
        public int Position;
        public eFieldKind Kind;
        public Field Follower { get; set; }
        public System.Windows.Forms.Button Button;
        public ePlayer Owner;

        public Field(int Value, int Position, eFieldKind Kind, ePlayer Player, System.Windows.Forms.Button Button)
        {
            this.Value = Value;
            this.Kind = Kind;
            this.Position = Position;
            this.Owner = Player;
            this.Button = Button;
            this.Button.Text = Value.ToString();
        }

        public void Fill()
        {
            Value++;                                    //Stein wird aus der Hand...                                    //...in das Feld gelegt
            Button.Text = Value.ToString();             //Die Anzeige wird aktualisiert
        }

        public int Empty()
        {
            int x = Value;
            Value = 0;
            Button.Text = Value.ToString();
            return x;
        }
    }
}
