using Helpers;
using Rallye;
using RallyeClasses;

static void main()
{
    Repository Repo = new();
    Repo.Init();

    bool exit = false;
    while (!exit)
    {
        int value = Helper.CreateMenu(["Créer un véhicule", "Voir un vehicule", "Mettre à jour un véhicule", "Supprimer un véhicule", "Afficher les véhicules", "Trier les véhicules", "Filtrer les véhicules", "Sauvegarder les vehicules", "Quitter"]);
        switch (value)
        {
            case 1: 
                Repo.CreateVehicule();
                break;
            case 2:
                Vehicule? vehicule = Repo.FindVehicule();
                Console.WriteLine(vehicule != null ? vehicule : "Aucun vehicule trouvé avec ce numéro");
                break;
            case 3:
                Repo.UpdateVehicule();
                break;
            case 4:
                Repo.DeleteVehicule();
                break;
            case 5:
                Repo.DisplayAll();
                break;
            case 6:
                Helper.DisplayError("EN COURS DE DEVELOPPEMENT");
                Repo.OrderBy();
                break;
            case 7:
                Repo.FilterBy();
                break;
            case 8:
                Repo.SerializeAndSave();
                break;
            case 9: 
                exit = true; 
                break;
            default:
                break;
        }
    }   
}

main();

