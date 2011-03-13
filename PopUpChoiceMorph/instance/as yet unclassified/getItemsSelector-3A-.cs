getItemsSelector: aSymbolOrString

	(nil = aSymbolOrString or:
	 ['nil' = aSymbolOrString or:
	 [aSymbolOrString isEmpty]])
		ifTrue: [^ getItemsSelector _ nil].

	getItemsSelector _ aSymbolOrString asSymbol.
