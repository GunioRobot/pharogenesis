classList
	classList _ classList select: [:each | Smalltalk includesKey: each withBlanksTrimmed asSymbol].
	^ classList