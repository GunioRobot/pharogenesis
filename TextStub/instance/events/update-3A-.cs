update: aSymbol
	aSymbol = spec getText ifTrue: [^ self refreshText].
	super update: aSymbol