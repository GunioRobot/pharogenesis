codePoint: integer 
	"Return a character whose encoding value is integer."
	#Fundmntl.
	(0 > integer or: [255 < integer])
		ifTrue: [self error: 'parameter out of range 0..255'].
	^ CharacterTable at: integer + 1