internLoadedSymbol: aStringOrMultiSymbol 

	aStringOrMultiSymbol isOctetString
		ifTrue: [^ Symbol intern: aStringOrMultiSymbol].
	^ (self lookupForLoadedSymbol: aStringOrMultiSymbol)
		ifNil: [NewMultiSymbols
				add: ((aStringOrMultiSymbol isKindOf: MultiSymbol)
						ifTrue: [aStringOrMultiSymbol]
						ifFalse: [(self new: aStringOrMultiSymbol size)
								string: aStringOrMultiSymbol])]
