update: aSymbol
	aSymbol = #packages ifTrue: [ self packagesChanged ]