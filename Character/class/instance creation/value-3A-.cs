value: anInteger 
	"Answer the Character whose value is anInteger."

	anInteger > 255 ifTrue: [^ MultiCharacter value: anInteger].
	^ CharacterTable at: anInteger + 1.
