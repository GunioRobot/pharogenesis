lookupForLoadedSymbol: aStringOrMultiSymbol

	^(MultiSymbolTable likeLoadedSymbol: aStringOrMultiSymbol) ifNil: [
		NewMultiSymbols likeLoadedSymbol: aStringOrMultiSymbol
	].
