characterBlockAtPoint: aPoint in: aParagraph
	"Answer a CharacterBlock for character in aParagraph at point aPoint. It 
	is assumed that aPoint has been transformed into coordinates appropriate 
	to the text's destination form rectangle and the composition rectangle."

	self initializeFromParagraph: aParagraph clippedBy: aParagraph clippingRectangle.
	characterPoint _ aPoint.
	^self buildCharacterBlockIn: aParagraph