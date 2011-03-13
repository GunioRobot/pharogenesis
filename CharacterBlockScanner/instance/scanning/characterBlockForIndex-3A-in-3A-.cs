characterBlockForIndex: targetIndex in: aParagraph 
	"Answer a CharacterBlock for character in aParagraph at targetIndex. The 
	coordinates in the CharacterBlock will be appropriate to the intersection 
	of the destination form rectangle and the composition rectangle."

	super 
		initializeFromParagraph: aParagraph 
		clippedBy: aParagraph clippingRectangle.
	characterIndex _ targetIndex.
	characterPoint _ 
		aParagraph rightMarginForDisplay @ 
			(aParagraph topAtLineIndex: 
				(aParagraph lineIndexOfCharacterIndex: characterIndex)).
	^self buildCharacterBlockIn: aParagraph