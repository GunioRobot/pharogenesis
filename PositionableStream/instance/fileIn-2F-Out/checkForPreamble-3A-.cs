checkForPreamble: chunk
	((chunk beginsWith: '"Change Set:') and: [Smalltalk changes preambleString == nil])
		ifTrue: [Smalltalk changes preambleString: chunk].
	((chunk beginsWith: '"Postscript:') and: [Smalltalk changes postscriptString == nil])
		ifTrue: [Smalltalk changes postscriptString: chunk].
							
