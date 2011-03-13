update: aSymbol
	inputSelectors do:
		[:s | aSymbol = s ifTrue: [^ self fire]].