newForJapaneseFromEFontBDFFile: fileName name: aString overrideWith: otherFileName

	| n |
	n _ self new.
	n readEFontBDFForJapaneseFromFile: fileName name: aString overrideWith: otherFileName.
	^ n.
