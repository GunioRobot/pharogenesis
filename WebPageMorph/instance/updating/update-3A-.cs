update: aSymbol
	| symbol |
	symbol _ aSymbol.
	symbol == nil
		ifTrue:[ symbol _ Color white]. 
	
	super update: symbol.

	aSymbol == getBgSelector ifTrue:
		[ (self isImage: self getBg) ifTrue:[image _ self drawImage: self getBg]
								ifFalse:[ image _ nil.
										self color: self getBg]]