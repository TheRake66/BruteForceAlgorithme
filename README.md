# BruteForceAlgorithme

Pour brute force on utilise un array :
L'array de base :
[-1, -1, -1, -1, -1, etc..., -1]

On calcule comme un calcul de base (2, 10, 16, bon bah la c'est base 191)

[0, -1, -1, -1, -1, ..., -1]

On fait +1
[1, -1, -1, -1, -1, ..., -1]

On fait +1
etc...
[191, -1, -1, -1, -1, ..., -1]

On fait +1
[192, -1, -1, -1, -1, ..., -1]

On décalle
[0, 0, -1, -1, -1, ..., -1]

On fait +1
[0, 1, -1, -1, -1, ..., -1]


Puis on converti en caracteres

[5, 26, 67, -1, -1, ..., -1]
 
 |  |   |
 v  v   v
 
 5  Q   Ç
 