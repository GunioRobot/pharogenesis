actionSelector: aSymbolOrString

	(nil = aSymbolOrString or:
	 ['nil' = aSymbolOrString or:
	 [aSymbolOrString isEmpty]])
		ifTrue: [^ setValueSelector _ nil].

	setValueSelector _ aSymbolOrString asSymbol.
