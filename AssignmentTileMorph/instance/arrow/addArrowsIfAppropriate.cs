addArrowsIfAppropriate
	"If the receiver's slot is of an appropriate type, add arrows to the tile.  The list of types wanting arrows is at this point simply hard-coded."

	(#(number sound boolean menu buttonPhase) includes: dataType)  ifTrue: [self addArrows]