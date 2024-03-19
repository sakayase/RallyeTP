using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyeClasses
{
    public class Voiture : Vehicule
    {
        public int Puissance {  get; set; }

        public Voiture(string Marque, string Model, string Numero, int Puissance) : base(Marque, Model, Numero)
        {
            this.Puissance = Puissance;
        }

        public override string ToString()
        {
            return base.ToString() + $"| Puissance: {Puissance}cv";
        }
    }
}
