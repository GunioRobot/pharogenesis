update: aSymbol
	aSymbol == #messageListChanged ifTrue: [^ self].
	aSymbol == #classListChanged ifTrue: [^ self].
	aSymbol == #autoSelect ifTrue:
		[controller setSearch: model autoSelectString;
				againOrSame: true.
		^ self].
	^ super update: aSymbol