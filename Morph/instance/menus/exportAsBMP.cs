exportAsBMP
	| fName |
	fName _ FillInTheBlank request:'Please enter the name' translated initialAnswer: self externalName,'.bmp'.
	fName isEmpty ifTrue:[^self].
	self imageForm writeBMPfileNamed: fName.