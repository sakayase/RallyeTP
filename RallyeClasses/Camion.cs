using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyeClasses
{
    public class Camion : Vehicule
    {
        public int Poids { get; set; }

        public Camion (string Marque, string Model, string Numero, int Poids) : base(Marque, Model, Numero)
        {
            this.Poids = Poids;
        }
        public override string ToString()
        {
            return base.ToString() + $"| Poids: {Poids}kg";
        }
    }
}
