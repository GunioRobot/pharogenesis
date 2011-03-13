update: aSymbol
	aSymbol = #relabel
		ifTrue: [^ self setLabel: model labelString].
