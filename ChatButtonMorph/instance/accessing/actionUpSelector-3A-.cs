actionUpSelector: aSymbolOrString


	(nil = aSymbolOrString or:
	 ['nil' = aSymbolOrString or:
	 [aSymbolOrString isEmpty]])
		ifTrue: [^ actionUpSelector _ nil].

	actionUpSelector _ aSymbolOrString asSymbol.