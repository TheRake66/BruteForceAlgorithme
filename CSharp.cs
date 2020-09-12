// Importation des bibliothèques
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Définition des variables
            int MinSize = 0;
            int MaxSize = 20;
            char[] charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\\? ".ToCharArray();
            int[] array = new int[MaxSize];

            // Création de l'array
            for (int i = 0; i < array.Length; i++)
            {
                if (i < MinSize)
                {
                    array[i] = 0;
                }
                else
                {
                    array[i] = -1;
                }
            }
            

            // Boucle du brute forçage
            while (true)
            {
                string password = "";
                array[0]++;

                // Calcul de l'array
                for (int i = 0; i < MaxSize - 1; i++)
                {
                    // Gestion du calcul de base
                    if (array[i] > charset.Length - 1)
                    {
                        array[i] = 0;
                        if (i == MaxSize - 1)
                        {
                            Environment.Exit(0); // Fin
                        }
                        else
                        {
                            array[i + 1]++;
                        }
                    }

                    // Convertion en caractères
                    if (array[i] > -1)
                    {
                        password += charset[array[i]];
                    }
                    else if (array[i] == -1)
                    {
                        break;
                    }
                }

                Console.WriteLine(password);
            }
        }
    }
}
