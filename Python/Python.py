# Importation des bibliotheques
import sys
from hashlib import sha256


# Definition des variables
hash = '6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090'
salt = '123'
minsize = 0
maxsize = 10
charset = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyz[]~@#$-_+{};:,./\\?'


# Calcul des variables
rang = range(maxsize)
maxrang = maxsize - 1
carray = list(charset)
csize = len(carray)
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
            password += carray[array[i]]
        else:
            break
            
	
    # Hash le mot de passe genere en sha256
    hashed = sha256((password + salt).encode('utf-8')).hexdigest()
    
    
    # Verifi la correspondance
    if hashed == hash:
        print('Le mot de passe est : "' + password + '"')
        sys.exit(0) # Fin