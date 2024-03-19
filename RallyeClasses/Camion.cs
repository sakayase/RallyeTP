using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RallyeClasses
{
    [JsonDerivedType(typeof(Camion), "camion")]
    public class Camion : Vehicule
    {
        public int Poids { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"| Poids: {Poids}kg";
        }
    }
}
