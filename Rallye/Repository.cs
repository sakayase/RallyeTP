using Helpers;
using RallyeClasses;
using static Helpers.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Rallye
{
    public class Repository
    {
        List<Vehicule> Vehicules = []; // Make private ?
        private string path = "vehicules.json";

        public async void Init()
        {         
            string? json = await Helper.ReadFromFile(path);
            if (json != null)
            {
                DeserialiseJson(json);
            } 
        }

        public void DeserialiseJson(string json)
        {
            this.Vehicules = JsonSerializer.Deserialize<List<Vehicule>>(json) ?? [];
        }

        public async void SerializeAndSave()
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    IncludeFields = true,
                    WriteIndented = true,
                };
                string json = JsonSerializer.Serialize(Vehicules, options);
                await File.WriteAllTextAsync(path, json);
            } catch
            {
                Helper.DisplayError("Erreur lors de la sauvegarde.");
            }
        }

        /// <summary>
        /// Demande à l'utilisateur un numéro d'imat et retourne le véhicule associé (null si pas trouvable)
        /// </summary>
        /// <returns>Un vehicule ou null si le numéro ne correspond à rien</returns>
        public Vehicule? FindVehicule()
        {
            string numero = Helper.PromptString("Numéro (imat) du vehicule :");
            return Vehicules.Find(v => v.Numero == numero);
        }
        
        /// <summary>
        /// Demande à l'utilisateur de créer un véhicule et l'enregistre dans le json une fois crée
        /// </summary>
        public void CreateVehicule()
        {
            int type = Helper.CreateMenu(["Voiture", "Camion"], "Quel type de véhicule voulez vous créer ?");
            switch (type)
            {
                case 1:
                    Voiture voiture = CreateVoiture();
                    Vehicules.Add(voiture);
                    break;
                case 2:
                    Camion camion = CreateCamion();
                    Vehicules.Add(camion);
                    break;
            }
        }

        /// <summary>
        /// Demande un numéro d'imat et si le véhicule existe, proposer à l'utilisateur de modifier ses champs
        /// </summary>
        public void UpdateVehicule()
        {
            Vehicule? vehicule = FindVehicule();
            if (vehicule == null) return;

            bool exitUpdate = false;
            if (vehicule is Camion camion)
            {
                while (!exitUpdate)
                {
                int value = Helper.CreateMenu([$"Marque : {camion.Marque}", $"Modele : {camion.Modele}", $"Numero : {camion.Numero}", $"Poids : {camion.Poids}", "Quitter"], "Champs à modifier");
                    switch (value)
                    {
                        case 1:
                            camion.Marque = Helper.PromptString("Marque du camion :", Validators.ValidateMarque);
                            break;
                        case 2:
                            camion.Modele = Helper.PromptString("Modele du camion :");
                            break;
                        case 3:
                            camion.Numero = Helper.PromptString("Numero (imat) du camion :", Validators.ValidateNumero);
                            break;
                        case 4:
                            camion.Poids = Helper.PromptInt("Poids du camion : ", Validators.ValidatePoids);
                            break;
                        case 5:
                            exitUpdate = true;
                            break;
                    }
                }
            } else if (vehicule is Voiture voiture)
            {
                while (!exitUpdate)
                {
                    int value = Helper.CreateMenu([$"Marque : {voiture.Marque}", $"Modele : {voiture.Modele}", $"Numero : {voiture.Numero}", $"Puissance : {voiture.Puissance}", "Quitter"], "Champs à modifier");
                    switch (value)
                    {
                        case 1:
                            voiture.Marque = Helper.PromptString("Marque de la voiture :", Validators.ValidateMarque);
                            break;
                        case 2:
                            voiture.Modele = Helper.PromptString("Modele de la voiture :");
                            break;
                        case 3:
                            voiture.Numero = Helper.PromptString("Numero (imat) de la voiture :", Validators.ValidateNumero);
                            break;
                        case 4:
                            voiture.Puissance = Helper.PromptInt("Puissance de la voiture (en cv) :", Validators.ValidatePuissance);
                            break;
                        case 5:
                            exitUpdate = true;
                            break;
                    }
                }
            }
        }

        public void DeleteVehicule()
        {
            Vehicule? vehicule = FindVehicule();
            if (vehicule == null) return;
            Vehicules.Remove(vehicule);
        }
       



        private static Voiture CreateVoiture()
        {
            string marque = Helper.PromptString("Marque de la voiture :", Validators.ValidateMarque);
            string modele = Helper.PromptString("Modele de la voiture :");
            string numero = Helper.PromptString("Numero (imat) de la voiture :", Validators.ValidateNumero);
            int puissance = Helper.PromptInt("Puissance (en cv) de la voiture :"); 
            Voiture voiture = new Voiture();
            voiture.Marque = marque;
            voiture.Numero = numero;
            voiture.Modele = modele;
            voiture.Puissance = puissance;
            return voiture;
        }

        private static Camion CreateCamion()
        {
            string marque = Helper.PromptString("Marque du camion :", Validators.ValidateMarque);
            string modele = Helper.PromptString("Modele du camion :");
            string numero = Helper.PromptString("Numero (imat) du camion :", Validators.ValidateNumero);
            int poids = Helper.PromptInt("Poids(en kg) du camion :");
            Camion camion = new();
            camion.Marque = marque;
            camion.Numero = numero;
            camion.Poids = poids;
            camion.Modele = modele;
            return camion;
        }

        public void DisplayAll()
        {
            Console.WriteLine("");
            Console.WriteLine("**********************");
            Console.WriteLine("");
            Vehicules.ForEach(v => { Console.WriteLine(v.ToString()); });
            Console.WriteLine("");
            Console.WriteLine("**********************");
            Console.WriteLine("");
        }

        public void DisplayList(List<Vehicule> list) 
        {
            Console.WriteLine("");
            Console.WriteLine("**********************");
            Console.WriteLine("");
            list.ForEach(v => { Console.WriteLine(v.ToString()); });
            Console.WriteLine("");
            Console.WriteLine("**********************");
            Console.WriteLine("");
        }

        public void OrderBy()
        {
            bool exitOrder = false;
            while (!exitOrder)
            {
                bool asc = false;
                int input = Helper.CreateMenu(["Marque", "Modele", "Numero", "Puissance", "Poids", "Quitter"], "Trier par quelle propriété ?");
                List<Vehicule> filteredVehicules = new();
                List<Voiture> voitures = Vehicules.Where(predicate: v => v is Voiture).Cast<Voiture>().ToList();
                List<Camion> camions = Vehicules.Where(predicate: v => v is Camion).Cast<Camion>().ToList();
                switch (input)
                {
                    case 1:
                        asc = Helper.PromptBool("Ordre ascendant (y/n) ?");
                        if (asc)
                        {
                            DisplayList(Vehicules.OrderBy(v => v.Marque).ToList());
                        } else
                        {
                            DisplayList(Vehicules.OrderByDescending(v => v.Marque).ToList());
                        }
                        break;

                    case 2:
                        asc = Helper.PromptBool("Ordre ascendant (y/n) ?");
                        if (asc)
                        {
                            DisplayList(Vehicules.OrderBy(v => v.Modele).ToList());
                        }
                        else
                        {
                            DisplayList(Vehicules.OrderByDescending(v => v.Modele).ToList());
                        }
                        break;

                    case 3:
                        asc = Helper.PromptBool("Ordre ascendant (y/n) ?");
                        if (asc)
                        {
                            DisplayList(Vehicules.OrderBy(v => v.Numero).ToList());
                        }
                        else
                        {
                            DisplayList(Vehicules.OrderByDescending(v => v.Numero).ToList());
                        }
                        break;

                    case 4:
                        asc = Helper.PromptBool("Ordre ascendant (y/n) ?");
                        if (asc)
                        {
                            DisplayList(voitures.OrderBy(v => v.Puissance).Cast<Vehicule>().ToList());
                        }
                        else
                        {
                            DisplayList(voitures.OrderByDescending(v => v.Puissance).Cast<Vehicule>().ToList());
                        }
                        break;

                    case 5:
                        asc = Helper.PromptBool("Ordre ascendant (y/n) ?");
                        if (asc)
                        {
                            DisplayList(camions.OrderBy(v => v.Poids).Cast<Vehicule>().ToList());
                        }
                        else
                        {
                            DisplayList(camions.OrderByDescending(v => v.Poids).Cast<Vehicule>().ToList());
                        }
                        break;

                    case 6:
                        exitOrder = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Affiche un menu à l'utilisateur qui doit choisir une proprieté sur laquelle filtrer
        /// Si c'est disponible, demande un comparateur pour faire le filtre.
        /// </summary>
        public void FilterBy()
        {
            bool exitFilter = false;
            while (!exitFilter)
            {
                int input = Helper.CreateMenu(["Marque", "Modele", "Numero", "Puissance", "Poids", "Quitter"], "Filtrer par quelle propriété ?");
                List<Vehicule> filteredVehicules = new();
                List<Voiture> voitures = Vehicules.Where(predicate: v => v is Voiture).Cast<Voiture>().ToList();
                List<Camion> camions = Vehicules.Where(predicate: v => v is Camion).Cast<Camion>().ToList();

                string? comparateur;
                switch (input)
                {
                    case 1:
                        string marque = Helper.PromptString("Marque ?", Validators.ValidateMarque);
                        DisplayList(Vehicules.Where(v => v.Marque == marque).ToList());
                        break;

                    case 2:
                        string modele = Helper.PromptString("Modele ?", Validators.ValidateMarque);
                        DisplayList(Vehicules.Where(v => v.Modele == modele).ToList());
                        break;

                    case 3:
                        string numero = Helper.PromptString("Numero ?", Validators.ValidateMarque);
                        DisplayList(Vehicules.Where(v => v.Numero == numero).ToList());
                        break;

                    case 4:
                        int puissance = Helper.PromptInt("Puissance ?", Validators.ValidatePuissance);
                        comparateur = Helper.PromptString("Comparateur", Validators.ValidateComparateur);
                        Console.WriteLine(comparateur);
                        switch (comparateur)
                        {
                            case "=":
                                Console.WriteLine("1");
                                DisplayList(voitures.Where(v => v.Puissance == puissance).Cast<Vehicule>().ToList());
                                break;
                            case "<=":
                                Console.WriteLine("2");
                                DisplayList(voitures.Where(v => v.Puissance <= puissance).Cast<Vehicule>().ToList());
                                break;
                            case ">=":
                                Console.WriteLine("3");
                                DisplayList(voitures.Where(v => v.Puissance >= puissance).Cast<Vehicule>().ToList());
                                break;
                            case "<":
                                Console.WriteLine("4");
                                DisplayList(voitures.Where(v => v.Puissance < puissance).Cast<Vehicule>().ToList());
                                break;
                            case ">":
                                Console.WriteLine("5");
                                DisplayList(voitures.Where(v => v.Puissance > puissance).Cast<Vehicule>().ToList());
                                break;
                        }
                        break;

                    case 5:
                        int poids = Helper.PromptInt("Poids ?", Validators.ValidatePoids);
                        comparateur = Helper.PromptString("Comparateur", Validators.ValidateComparateur);
                        Console.WriteLine(comparateur);
                        switch (comparateur)
                        {
                            case "=":
                                Console.WriteLine("1");
                                DisplayList(camions.Where(v => v.Poids == poids).Cast<Vehicule>().ToList());
                                break;
                            case "<=":
                                Console.WriteLine("2");
                                DisplayList(camions.Where(v => v.Poids <= poids).Cast<Vehicule>().ToList());
                                break;
                            case ">=":
                                Console.WriteLine("3");
                                DisplayList(camions.Where(v => v.Poids >= poids).Cast<Vehicule>().ToList());
                                break;
                            case "<":
                                Console.WriteLine("4");
                                DisplayList(camions.Where(v => v.Poids < poids).Cast<Vehicule>().ToList());
                                break;
                            case ">":
                                Console.WriteLine("5");
                                DisplayList(camions.Where(v => v.Poids > poids).Cast<Vehicule>().ToList());
                                break;
                        }
                        break;

                    case 6:
                        exitFilter = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Genere un nombre donné de véhicules crées aléatoirement
        /// </summary>
        /// <param name="nb">Nombre de véhicules générés</param>
        public static void GenerateRandomList(int nb)
        {
            Random rand = new();

            List<Vehicule> genVehicules = new();
            for (int i = 0; i < nb; i++)
            {
                int type = rand.Next(minValue: 0, maxValue: 2);
                if (type == 0) // On genere une Voiture 
                {
                    string marque = MarquesVoiture[rand.Next(MarquesVoiture.Count() - 1)];
                    string modele = ModelesVoiture[rand.Next(ModelesVoiture.Count() - 1)];
                    Voiture voiture = new Voiture();
                    voiture.Marque = marque;
                    voiture.Modele = modele;
                    voiture.Numero = Helper.GenerateRandomNumero();
                    voiture.Puissance = rand.Next(50, 500);
                    genVehicules.Add(voiture);
                } else // On genere un Camion
                {
                    string marque = MarquesCamion[rand.Next(MarquesCamion.Count() - 1)];
                    string modele = ModelesCamion[rand.Next(ModelesCamion.Count() - 1)];
                    Camion camion= new Camion();
                    camion.Marque = marque; camion.Modele = modele;
                    camion.Numero = Helper.GenerateRandomNumero();
                    camion.Poids = rand.Next(3500, 20000);
                    genVehicules.Add(camion);
                }
            }
        }
    }
}
