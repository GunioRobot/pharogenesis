update: aSymbol
	aSymbol = #relabel
		ifTrue: [^ self setLabelTo: model labelString].
	^ super update: aSymbol