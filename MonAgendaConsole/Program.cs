using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;

namespace MonAgendaConsole
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Arguments du programme</param>
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager();
            string choise;
            string loc;
            bool run = true;

            do 
            {
                displayMenu();
                Console.Write("Votre choix : ");
                choise = Console.ReadLine();

                Console.WriteLine();

                switch (choise)
                {
                    case "0":
                        businessManager.EvenementsClassesDate().ToList().ForEach(value => Console.WriteLine(value.MonEvenement.Titre));
                        break;
                    case "1":
                        businessManager.ArtistesAssocies().ToList().ForEach(value => Console.WriteLine(value));
                        break;
                    case "2":
                        businessManager.LieuxUtilises().ToList().ForEach(value => Console.WriteLine(value));
                        break;
                    case "3":
                        Console.Write("Le lieu : ");
                        loc = Console.ReadLine();
                        businessManager.EvenementsPourLieu(loc).ToList().ForEach(value => Console.WriteLine(value));
                        break;
                    case "4":
                        run = false;
                        break;
                }

            } while (run);
        }

        /// <summary>
        /// Affiche le menu de sélection en console.
        /// </summary>
        private static void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------- MonAgendaConsole --------------------------");
            Console.WriteLine("|                                                                    |");
            Console.WriteLine("| 0 - Liste des événements prévus classés par date                   |");
            Console.WriteLine("| 1 - Liste des artistes associés par ordre alphabétique             |");
            Console.WriteLine("| 2 - Liste des lieux pour lequels il y a au moins un événement      |");
            Console.WriteLine("| 3 - Evenements associés pour un lieu donné                         |");
            Console.WriteLine("| 4 - Quitter                                                        |");
            Console.WriteLine("|                                                                    |");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
