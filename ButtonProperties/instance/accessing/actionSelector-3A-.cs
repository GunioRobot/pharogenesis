actionSelector: aSymbolOrString

	aSymbolOrString isEmptyOrNil ifTrue: [^actionSelector _ nil].
	aSymbolOrString = 'nil' ifTrue: [^actionSelector _ nil].
	actionSelector _ aSymbolOrString asSymbol.
