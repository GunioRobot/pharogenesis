intern: aStringOrMultiSymbol 

	aStringOrMultiSymbol isOctetString
		ifTrue: [^ Symbol intern: aStringOrMultiSymbol].
	^ (self lookup: aStringOrMultiSymbol)
		ifNil: [NewMultiSymbols
				add: ((aStringOrMultiSymbol isKindOf: MultiSymbol)
						ifTrue: [aStringOrMultiSymbol]
						ifFalse: [(self new: aStringOrMultiSymbol size)
								string: aStringOrMultiSymbol])]
