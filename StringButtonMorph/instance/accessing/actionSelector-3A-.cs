actionSelector: aSymbolOrString

	(nil = aSymbolOrString or:
	 ['nil' = aSymbolOrString or:
	 [aSymbolOrString isEmpty]])
		ifTrue: [^ actionSelector _ nil].

	actionSelector _ aSymbolOrString asSymbol.
