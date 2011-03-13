newFromEFontBDFFile: fileName name: aString ranges: ranges 
	| n |
	n := self new.
	n 
		readEFontBDFFromFile: fileName
		name: aString
		ranges: ranges.
	^ n