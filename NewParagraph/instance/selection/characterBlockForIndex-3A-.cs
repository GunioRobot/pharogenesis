characterBlockForIndex: index 
	"Answer a CharacterBlock for the character in text at index."
	^ (CharacterBlockScanner new text: text textStyle: textStyle)
		characterBlockAtPoint: nil index: index
		in: (lines at: (self lineIndexForCharacter: index))