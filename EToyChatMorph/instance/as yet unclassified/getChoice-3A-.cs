getChoice: aSymbol
	
	aSymbol == #acceptOnCR ifTrue: [^acceptOnCR ifNil: [true]].
	^false.
