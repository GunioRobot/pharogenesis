newFromEFontBDFFile: fileName name: aString ranges: ranges

	| n |
	n _ self new.
	n readEFontBDFFromFile: fileName name: aString ranges: ranges.
	^ n.
