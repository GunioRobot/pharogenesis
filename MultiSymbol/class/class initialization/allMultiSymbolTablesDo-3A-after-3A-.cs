allMultiSymbolTablesDo: aBlock after: aMultiSymbol

	NewMultiSymbols do: aBlock after: aMultiSymbol.
	MultiSymbolTable do: aBlock after: aMultiSymbol.
