using System.Text.Json.Serialization;

namespace RallyeClasses
{
    [JsonDerivedType(typeof(Voiture), typeDiscriminator: "voiture")]
    [JsonDerivedType(typeof(Camion), typeDiscriminator: "camion")]
    public class Vehicule
    {
        public string Marque { get; set; } = "";
        public string Modele { get; set; } = "";
        public string Numero { get; set; } = "";

        public override string ToString()
        {
            return $"Marque: {Marque} | Modele: {Modele} | Numero: {Numero} ";
        }
    }
}
