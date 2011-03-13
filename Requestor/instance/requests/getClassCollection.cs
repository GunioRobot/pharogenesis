getClassCollection
	^ self getSymbolCollection collect: [:className | Smalltalk at: className]