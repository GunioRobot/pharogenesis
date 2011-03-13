update: aSymbol 
	aSymbol == #allSelections
		ifTrue: [^ self displayView; emphasizeView].
	^ super update: aSymbol