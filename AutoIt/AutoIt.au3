#AutoIt3Wrapper_UseX64=y
#AutoIt3Wrapper_Change2CUI=y


; Importation des bibliotheques
#include <Crypt.au3>
#include <String.au3>
#include <StringConstants.au3>


; Definition des variables
$hash = '6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090'
$salt = '123'
$minsize = 0
$maxsize = 10
$charset = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyz[]~@#$-_+{};:,./\?'


; Calcul des variables
$carray = StringSplit($charset, '', 2)
$csize = UBound($carray) - 1
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
			$password &= $carray[$array[$i]]
		Else
			ExitLoop
		EndIf


	Next


    ; Hash le mot de passe genere en sha256
    $hashed = StringMid(_Crypt_HashData($password & $salt, $CALG_SHA_256), 3)


	; Verifi la correspondance
    If $hashed = $hash Then
	    ConsoleWrite('Le mot de passe est : "' & $password & '"' & @CRLF)
        Exit ; Fin
    EndIf
	
	
WEnd