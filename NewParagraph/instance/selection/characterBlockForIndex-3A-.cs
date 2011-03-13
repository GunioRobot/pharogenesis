characterBlockForIndex: index 
	"Answer a CharacterBlock for the character in text at index."
	| line |
	line _ lines at: (self lineIndexForCharacter: index).
	^ (CharacterBlockScanner new text: text textStyle: textStyle)
		characterBlockAtPoint: nil index: ((index max: line first) min: line last+1)
		in: line