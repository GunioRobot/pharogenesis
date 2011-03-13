selectionAsTiles
	"Try to make new universal tiles from the selected text"
	| selection tiles |

	selection _ self selection.
	self terminateAndInitializeAround:
		[self currentHand attachMorph: (tiles _ Player tilesFrom: selection).
		tiles align: tiles topLeft 
			 with: self currentHand position + tiles cursorBaseOffset].