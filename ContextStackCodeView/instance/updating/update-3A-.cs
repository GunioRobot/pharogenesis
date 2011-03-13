update: aSymbol
	(aSymbol == #contextStackList) | (aSymbol == #contextStackIndex)
		ifTrue: [^ self].
	aSymbol == #pc ifTrue: [^ self highlightPC].
	aSymbol == #contents ifTrue: [^ self updateDisplayContents].
	super update: aSymbol