value: anInteger 
	"Answer the Character whose value is anInteger."
	
	anInteger negative ifTrue:[self error: 'Characters expects a positive value.'].
	anInteger > 255 ifTrue: [^self basicNew setValue: anInteger].
	^ CharacterTable at: anInteger + 1.
