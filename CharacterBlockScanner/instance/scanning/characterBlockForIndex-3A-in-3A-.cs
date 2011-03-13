characterBlockForIndex: targetIndex in: aParagraph 
	"Answer a CharacterBlock for character in aParagraph at targetIndex. The 
	coordinates in the CharacterBlock will be appropriate to the intersection 
	of the destination form rectangle and the composition rectangle."
	self 
		initializeFromParagraph: aParagraph
		clippedBy: aParagraph clippingRectangle.
	characterIndex := targetIndex.
	characterPoint := aParagraph rightMarginForDisplay @ (aParagraph topAtLineIndex: (aParagraph lineIndexOfCharacterIndex: characterIndex)).
	^ self buildCharacterBlockIn: aParagraph