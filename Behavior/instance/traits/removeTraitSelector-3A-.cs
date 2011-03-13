removeTraitSelector: aSymbol
	self assert: [(self includesLocalSelector: aSymbol) not].
	self basicRemoveSelector: aSymbol