specAt: aSymbol ifAbsent: aBlock
	| classSymbol |
	classSpec ifNil:[^aBlock value].
	classSymbol _ classSpec at: aSymbol ifAbsent:[^aBlock value].
	classSymbol ifNil:[^aBlock value].
	^Smalltalk at: classSymbol ifAbsent: aBlock
	