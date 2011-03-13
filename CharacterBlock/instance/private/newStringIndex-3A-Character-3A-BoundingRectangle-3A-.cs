newStringIndex: anInteger Character: aCharacter BoundingRectangle: aRectangle

	stringIndex _ anInteger.
	character _ aCharacter.
	super origin: aRectangle topLeft.
	super corner: aRectangle corner