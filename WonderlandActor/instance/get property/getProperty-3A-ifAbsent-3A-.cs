getProperty: aSymbol ifAbsent: aBlock
	myProperties == nil ifTrue:[^aBlock value].
	^myProperties at: aSymbol ifAbsent: aBlock