attributesFor: aSymbol pixelHeight: aNumber
	
	(self textAttributesByPixelHeight includesKey: aNumber)
		ifFalse:[self initializeTextAttributesForPixelHeight: aNumber].
	^(self textAttributesByPixelHeight at: aNumber) at: aSymbol ifAbsent:[nil]