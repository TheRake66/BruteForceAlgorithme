// Importation des bibliotheques
#include <iostream>
#include <string>
#include "sha256.h"
using namespace std;


int main()
{


    // Definition des variables
    string hash = "6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090";
    string salt = "123";
    int minsize = 0;
    int maxsize = 10;
    string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyz[]~@#$-_+{};:,./\\?";


    // Calcul des variables
    int csize = charset.length() + 1;
    char* carray = new char[csize];
    strcpy(carray, charset.c_str());
    int* array = new int[maxsize];
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
                    exit(0); // Fin
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
        string hashed = sha256(password + salt);


        // Verifi la correspondance
        if (hashed == hash)
        {
            std::cout << "Le mot de passe est : \"" + password + "\"";
            exit(0); // Fin
        }


    }
}