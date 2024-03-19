namespace RallyeClasses
{
    public abstract class Vehicule
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Numero { get; set; }


        public Vehicule(string Marque, string Modele, string Numero)
        {
            this.Marque = Marque;
            this.Modele = Modele;
            this.Numero = Numero;
        }

        public override string ToString()
        {
            return $"Marque: {Marque} | Modele: {Modele} | Numero: {Numero} ";
        }
    }
}
