addArrowsIfAppropriate
	"If the receiver's slot is of an appropriate type, add arrows to the tile"
	(#(number sound boolean menu) includes: dataType)  ifTrue: [self addArrows]