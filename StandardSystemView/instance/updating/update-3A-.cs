update: aSymbol
	aSymbol = #relabel
		ifTrue: [^ self relabel: model labelString].
	^ super update: aSymbol