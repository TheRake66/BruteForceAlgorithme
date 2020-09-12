; Pour créer une instance CUI
#AutoIt3Wrapper_Change2CUI=y

; Définition des variables
$minsize = 0
$maxsize = 20
$charset = StringSplit("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghikjlmnopqrstuvwxyzÀÁÂÃÄÇÈÉÊËÌÍÏÑÒÓÔÕÖŠÚÛÜÙÝŸŽàáâãäçèéêëìíîïñòóôõöšúûüùýÿž[]~@#$-_+{};:,./\? ", "", 2)
Dim $array[$maxsize]

;Création de l'array
For $i = 0 To UBound($array)-1
	If $i < $minsize Then
		$array[$i] = 0
	Else
		$array[$i] = -1
	EndIf
Next


; Boucle du brute forçage
While 1

	$password = ""
	$array[0] += 1

	; Calcul de l'array
	For $i = 0 To $maxsize-1
	
		; Gestion du calcul de base
		If $array[$i] > UBound($charset)-1 Then
			$array[$i] = 0
			If $i = $maxsize-1 Then
				Exit
			Else
				$array[$i+1] += 1
			EndIf 
		EndIf	
		
		; Convertion en caractères
		If $array[$i] > -1 Then
			$password &= $charset[$array[$i]]
		EndIf
		If $array[$i] = -1 Then
			ExitLoop
		EndIf
	Next
	
	ConsoleWrite($password & @CRLF)
	
WEnd