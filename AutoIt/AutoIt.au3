#AutoIt3Wrapper_UseX64=y
#AutoIt3Wrapper_Change2CUI=y

; Importation des bibliotheques
#include <Crypt.au3>
#include <String.au3>
#include <StringConstants.au3>

; Definition des variables
$tobrute = 'ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad'
$minsize = 0
$maxsize = 20
$charset = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\\? '
$csize = StringLen($charset)
Dim $array[$maxsize + 1]
For $i = 0 To $maxsize
	$array[$i] = $i < $minsize ? 0 : -1
Next
$maxrang = $maxsize - 1

; Boucle du brute forcage
While 1

    ; Reset et increment
	$password = ""
	$array[0] += 1

	; Calcul de l'array
	For $i = 0 To $maxsize

		; Gestion du calcul de base
		If $array[$i] > $csize Then
			If $i < $maxrang Then
				$array[$i] = 0
				$array[$i + 1] += 1
			Else
				Exit ; Fin
			EndIf 
		EndIf	
		
		; Conversion en caracteres
		If $array[$i] > -1 Then
			$password &= StringMid($charset, $array[$i], 1)
		Else
			ExitLoop
		EndIf

	Next

    ; Hash le mot de passe genere en sha256
    $hashed = StringMid(_Crypt_HashData($password, $CALG_SHA_256), 3)

	; Verifi la correspondance
    If $hashed = $tobrute Then
	    ConsoleWrite('Le mot de passe est : "' & $password & '"' & @CRLF)
        Exit ; Fin
    EndIf
	
WEnd