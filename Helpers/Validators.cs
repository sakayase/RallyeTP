﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Validators
    {
        /// <summary>
        /// Valide un string de numero imat
        /// Il doit etre non vide et entre 4 et 6 characters
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public static bool ValidateNumero(string Numero)
        {
            if (string.IsNullOrEmpty(Numero))
            {
                Console.WriteLine("Le numéro ne peut être vide.");
                return false;
            }
            if (Numero.Length > 6 || Numero.Length < 4)
            {
                Console.WriteLine("Le numéro doit etre composé de 4 caracteres ou plus et 6 character ou moins.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valide le poids d'un camion
        /// Il doit être positif
        /// </summary>
        /// <param name="Poids"></param>
        /// <returns></returns>
        public static bool ValidatePoids(int Poids)
        {
            if (Poids <= 0) 
            {
                Console.WriteLine("Le poids doit etre positif.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valide la marque d'un vehicule
        /// Elle ne doit pas contenir de chiffre
        /// </summary>
        /// <param name="Marque"></param>
        /// <returns></returns>
        public static bool ValidateMarque(string Marque)
        {
            if (Marque.Any(c => char.IsDigit(c))) 
            {
                Console.WriteLine("La marque ne doit pas contenir de chiffres");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valide la puissance d'une voiture
        /// Elle doit etre positive
        /// </summary>
        /// <param name="Puissance"></param>
        /// <returns></returns>
        public static bool ValidatePuissance(int Puissance)
        {
            if (Puissance <= 0)
            {
                Console.WriteLine("La puissance doit être positive");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valide un numéro de menu
        /// Il doit etre comprit entre 1 et la taille du menu
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="listMenu"></param>
        /// <returns></returns>
        public static bool ValidateMenu(int menu, List<string> listMenu)
        {
            if (menu <= 0 || menu >= listMenu.Count + 1)
            {
                Console.WriteLine($"Le numéro choisi doit etre entre 1 et {listMenu.Count}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valide un comparateur (=, <, >, <=, >=)
        /// </summary>
        /// <param name="comparateur"></param>
        /// <returns></returns>
        public static bool ValidateComparateur(string comparateur)
        {
            if (comparateur != "=" && comparateur != "<" && comparateur != ">" && comparateur != "<=" && comparateur != ">=")
            {
                Console.WriteLine("Le comparateur n'est pas valide (=, >=, <=, >, < :");
                return false;
            }
            return true;
        }
    }
}
