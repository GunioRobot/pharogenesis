exportAsGIF
	| fName |
	fName _ FillInTheBlank request:'Please enter the name' translated initialAnswer: self externalName,'.gif'.
	fName isEmpty ifTrue:[^self].
	GIFReadWriter putForm: self imageForm onFileNamed: fName.