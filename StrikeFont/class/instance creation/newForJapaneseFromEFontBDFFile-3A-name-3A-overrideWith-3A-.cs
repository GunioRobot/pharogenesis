newForJapaneseFromEFontBDFFile: fileName name: aString overrideWith: otherFileName 
	| n |
	n := self new.
	n 
		readEFontBDFForJapaneseFromFile: fileName
		name: aString
		overrideWith: otherFileName.
	^ n