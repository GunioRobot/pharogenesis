newForKoreanFromEFontBDFFile: fileName name: aString overrideWith: otherFileName 
	| n |
	n := self new.
	n 
		readEFontBDFForKoreanFromFile: fileName
		name: aString
		overrideWith: otherFileName.
	^ n