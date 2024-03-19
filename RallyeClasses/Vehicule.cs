namespace RallyeClasses
{
    public abstract class Vehicule
    {
        public required string Marque { get; set; }
        public required string Modele { get; set; }
        public required string Numero { get; set; }


/*        Vehicule(string Marque, string Modele, string Numero)
        {
            this.Marque = Marque;
            this.Modele = Modele;
            this.Numero = Numero;
        }*/
    }
}
