using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RallyeClasses
{
    [JsonDerivedType(typeof(Voiture), "voiture")]

    public class Voiture : Vehicule
    {
        public int Puissance {  get; set; }

        public override string ToString()
        {
            return base.ToString() + $"| Puissance: {Puissance}cv";
        }
    }
}
