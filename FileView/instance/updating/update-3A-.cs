update: aSymbol
	aSymbol = #relabel
		ifTrue: [^ self topView relabel: model labelString].
	^ super update: aSymbol