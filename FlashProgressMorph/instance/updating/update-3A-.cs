update: aSymbol 
	aSymbol == #contents
		ifTrue: 
			[lastValue _ value contents.
			self changed]