# Importation des bibliotheques
import sys
from hashlib import sha256

# Definition des variables
tobrute = 'ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad'
minsize = 0
maxsize = 20
charset = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\\? '
rang = range(maxsize)
maxrang = maxsize - 1
csize = len(charset)
array = [0 if _ < minsize else -1 for _ in rang]

# Boucle du brute forcage
while True:

    # Reset et increment
    password = ''
    array[0] += 1
    
	# Calcul de l'array
    for i in rang:
        
		# Gestion du calcul de base
        if array[i] == csize:
            if i < maxrang:
                array[i] = 0
                array[i + 1] += 1
            else:
                sys.exit(0) # Fin
				
        # Conversion en caracteres
        if array[i] > -1:
            password += charset[array[i]]
        else:
            break
	
    # Hash le mot de passe genere en sha256
    hashed = sha256(password.encode('utf-8')).hexdigest()
    
    # Verifi la correspondance
    if hashed == tobrute:
        print('Le mot de passe est : "' + password + '"')
        sys.exit(0) # Fin
    
	