lookup: aStringOrMultiSymbol

	^(MultiSymbolTable like: aStringOrMultiSymbol) ifNil: [
		NewMultiSymbols like: aStringOrMultiSymbol
	].
