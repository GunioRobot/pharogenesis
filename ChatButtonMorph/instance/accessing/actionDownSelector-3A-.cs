actionDownSelector: aSymbolOrString

	(nil = aSymbolOrString or:
	['nil' = aSymbolOrString or:
	[aSymbolOrString isEmpty]])
		ifTrue: [^actionDownSelector _ nil].

	actionDownSelector _ aSymbolOrString asSymbol.