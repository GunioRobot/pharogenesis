characterBlockAtPoint: aPoint 
	"Answer a CharacterBlock for the character in the text at aPoint."
	| line |
	line _ lines at: (self lineIndexForPoint: aPoint).
	^ (CharacterBlockScanner new text: text textStyle: textStyle)
		characterBlockAtPoint: (aPoint adhereTo: line rectangle) index: nil
		in: line