value: anInteger 
	"Answer the Character whose value is anInteger."

	anInteger > 255 ifTrue: [^self basicNew setValue: anInteger].
	^ CharacterTable at: anInteger + 1.
