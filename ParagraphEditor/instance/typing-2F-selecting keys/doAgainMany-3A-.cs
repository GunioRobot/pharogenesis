doAgainMany: characterStream 
	"Do the previous thing again repeatedly. 1/26/96 sw"

	self closeTypeIn: characterStream.
	self againOrSame: (UndoMessage sends: #undoAgain:andReselect:typedKey:) many: true.
	^ true