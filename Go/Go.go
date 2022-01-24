package main

// Importation des bibliotheques
import (
	"crypto/sha256"
	"encoding/hex"
	"fmt"
	"os"
)

func main() {

	// Definition des variables
	tobrute := "ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad"
	minsize := 0
	maxsize := 20
	charset := "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\\? "
	csize := len(charset)
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
				password += string(charset[array[i]])
			} else {
				break
			}

		}

		// Hash le mot de passe genere en sha256
		h := sha256.Sum256([]byte(password))
		hashed := hex.EncodeToString(h[:])

		// Verifi la correspondance
		if string(hashed) == tobrute {
			fmt.Print("Le mot de passe est : \"" + password + "\"")
			os.Exit(0) // Fin
		}

	}

}
