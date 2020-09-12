# Importation des bibliothèques
import sys

# Définition des variables
minsize = 0
maxsize = 20
charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\? "
array = []

# Création de l'array
for i in range(maxsize-1):
    if i < minsize:
        array.append(0)
    else:
        array.append(-1)


# Boucle du brute forçage
while True:

    password = ""
    array[0] += 1
    
	# Calcul de l'array
    for i in range(maxsize-1):
        
		# Gestion du calcul de base
        if array[i] > len(charset)-1:
            array[i] = 0
            if i == maxsize-1:
                sys.exit(0) # Fin
            else:
                array[i+1] += 1
				
        # Convertion en caractères
        if array[i] > -1:
            password = password + charset[array[i]]
        elif array[i] == -1:
            break
			
    print(password)
	
	
	
	