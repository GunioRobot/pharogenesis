newForKoreanFromEFontBDFFile: fileName name: aString overrideWith: otherFileName

	| n |
	n _ self new.
	n readEFontBDFForKoreanFromFile: fileName name: aString overrideWith: otherFileName.
	^ n.
