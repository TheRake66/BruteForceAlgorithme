package main


// Importation des bibliotheques
import (
    "crypto/sha256"
    "encoding/hex"
    "fmt"
    "os"
    "strings"
)


func main() {


    // Definition des variables
    hash := "6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090"
    salt := "123"
    minsize := 0
    maxsize := 10
    charset := "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyz[]~@#$-_+{};:,./\\?"


    // Calcul des variables
    carray := strings.Split(charset, "")
    csize := len(carray)
    array := make([]int, 0)
    for i := 0; i < maxsize; i++ {
        if i < minsize {
            array = append(array, 0)
        } else {
            array = append(array, -1)
        }
    }
    maxrang := maxsize - 1


    // Boucle du brute forcage
    for {


        // Reset et increment
        password := ""
        array[0] += 1


        // Calcul de l'array
        for i := 0; i < maxsize; i++ {


            // Gestion du calcul de base
            if array[i] == csize {
                if i < maxrang {
                    array[i] = 0
                    array[i+1] += 1
                } else {
                    os.Exit(0) // Fin
                }
            }


            // Conversion en caracteres
            if array[i] > -1 {
                password += carray[array[i]]
            } else {
                break
            }


        }
		

        // Hash le mot de passe genere en sha256
        h := sha256.Sum256([]byte(password + salt))
        hashed := hex.EncodeToString(h[:])


        // Verifi la correspondance
        if string(hashed) == hash {
            fmt.Print("Le mot de passe est : \"" + password + "\"")
            os.Exit(0) // Fin
        }
		

    }
}
