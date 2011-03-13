classList
	classList := classList select: [:each | Smalltalk includesKey: each withBlanksTrimmed asSymbol].
	^ classList