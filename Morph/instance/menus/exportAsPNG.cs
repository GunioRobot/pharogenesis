exportAsPNG
	| fName |
	fName _ FillInTheBlank request:'Please enter the name' translated initialAnswer: self externalName,'.png'.
	fName isEmpty ifTrue:[^self].
	PNGReadWriter putForm: self imageForm onFileNamed: fName.