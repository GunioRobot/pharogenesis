fromString: aString 
	"Answer an instance of me whose characters are those of the argument, 
	aString."

	^self string: aString attribute: (TextFontChange fontNumber: 1)