getTag: aSymbol 
	^ self tags at: aSymbol ifAbsent: [nil]