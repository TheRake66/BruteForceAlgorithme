﻿// Importation des bibliotheques
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
            string hash = "6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090";
            string salt = "123";
            int minsize = 0;
            int maxsize = 10;
            string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyz[]~@#$-_+{};:,./\\?";


            // Calcul des variables
            char[] carray = charset.ToCharArray();
            int csize = charset.carray;
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
                        password += carray[array[i]];
                    }
                    else
                    {
                        break;
                    }
					

                }


                // Hash le mot de passe genere en sha256
                string hashed = String.Concat(SHA256.Create()
                            .ComputeHash(Encoding.UTF8.GetBytes(password + salt))
                            .Select(item => item.ToString("x2")));


                // Verifi la correspondance
                if (hashed == hash)
                {
                    Console.WriteLine("Le mot de passe est : \"" + password +"\"");
                    Environment.Exit(0); // Fin
                }


            }
        }
    }
}
