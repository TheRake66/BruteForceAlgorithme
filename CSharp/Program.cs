// Importation des bibliotheques
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Definition des variables
            string tobrute = "ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad";
            int minsize = 0;
            int maxsize = 20;
            string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\\? ";
            int csize = charset.Length;
            int[] array = new int[maxsize];
            for (int i = 0; i < maxsize; i++)
            {
                array[i] = i < minsize ? 0 : -1;
            }
            int maxrang = maxsize - 1;

            // Boucle du brute forcage
            while (true)
            {

                // Reset et increment
                string password = "";
                array[0]++;

                // Calcul de l'array
                for (int i = 0; i < maxsize; i++)
                {

                    // Gestion du calcul de base
                    if (array[i] == csize)
                    {
                        if (i < maxrang)
                        {
                            array[i] = 0;
                            array[i + 1]++;
                        }
                        else
                        {
                            Environment.Exit(0); // Fin
                        }
                    }

                    // Convertion en caracteres
                    if (array[i] > -1)
                    {
                        password += charset[array[i]];
                    }
                    else
                    {
                        break;
                    }

                }

                // Hash le mot de passe genere en sha256
                string hashed = String.Concat(SHA256.Create()
                            .ComputeHash(Encoding.UTF8.GetBytes(password))
                            .Select(item => item.ToString("x2")));

                // Verifi la correspondance
                if (hashed == tobrute)
                {
                    Console.WriteLine("Le mot de passe est : \"" + password +"\"");
                    Environment.Exit(0); // Fin
                }

            }
        }
    }
}
