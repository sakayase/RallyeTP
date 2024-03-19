using System;

namespace Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Demande à l'utilisateur de rentrer un string dans la console avec possibilité de valider la valeur
        /// </summary>
        /// <param name="label"></param>
        /// <param name="validator">Fonction de validation</param>
        /// <returns></returns>
        public static string PromptString(string label = "String ?", Func<string, bool>? validator = null)
        {
            Console.WriteLine(label);
            string input = "";
            bool isValid = false;
            while (!isValid)
            {
                input = Console.ReadLine() ?? "";
                if (validator != null)
                {
                    isValid = validator(input);
                } else
                {
                    isValid = true;
                }
            }
            return input;
        }

        /// <summary>
        /// Demande à l'utilisateur de rentrer un int dans la console avec possibilité de valider la valeur
        /// </summary>
        /// <param name="label"></param>
        /// <param name="validator">Fonction de validation</param>
        /// <returns></returns>
        public static int PromptInt(string label = "Entier ?", Func<int, bool>? validator = null)
        {
            bool hasParsed = false;
            int num = 0;
            string input;
            while (!hasParsed)
            {
                input = PromptString(label);
                hasParsed = int.TryParse(input, out num);
                if (validator != null)
                {
                    hasParsed = validator(num);
                }
            }
            return num;
        }

        public static int PromptIntMenu(List<string> menus, string label = "Valeur ?", Func<int, List<string>, bool>? validator = null)
        {
            bool hasParsed = false;
            int num = 0;
            string input;
            while (!hasParsed)
            {
                input = PromptString(label);
                hasParsed = int.TryParse(input, out num);
                if (validator != null)
                {
                    hasParsed = validator(num, menus);
                }
            }
            return num;
        }

        public static bool PromptBool(string label = "bool ?")
        {
            while (true)
            {
                string input = PromptString(label).ToLower();
                if (input == "y" || input == "oui" || input == "o")
                {
                    return true;
                } else if (input == "n" || input == "non" || input == "no")
                {
                    return false;
                } else
                {
                    Console.WriteLine("La valeur doit etre \"y\" ou \"oui\" ou \"o\" ou \"n\" ou \"non\" ou \"no\"");
                }
            }
        }

        public static async Task<string?> ReadFromFile(string path)
        {
            try
            {
                return await File.ReadAllTextAsync(path);
            } catch (FileNotFoundException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Crée un menu avec la liste de string, chaque element est une valeur du menu, retourne le numéro (affiché donc n+1 pour un array) du menu séléctionné.
        /// </summary>
        /// <param name="menu">Liste des elements du menu</param>
        /// <param name="label"></param>
        /// <returns>Numéro (int) du menu séléctionné</returns>
        public static int CreateMenu(List<string> menus, string label = "Quelle action ?")
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(label);
            Console.WriteLine("");
            for (int i = 0; i < menus.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {menus[i]}");
            }
            Console.WriteLine("");
            return PromptIntMenu(menus, "Entrez la valeur", Validators.ValidateMenu) ;

        }

        /// <summary>
        /// Genere un imat random non unique
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomNumero()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ1234567890";
            string Numero = "";
            Random rand = new();
            for (int i = 0; i < rand.Next(4,6); i++) // Taille du numéro entre 4 et 6
            {
                Numero += chars[rand.Next(chars.Length - 1)]; // On choisit une lettre au hasard
            }

            return Numero;
        }

        /// <summary>
        /// Affiche un message en rouge dans la console
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
