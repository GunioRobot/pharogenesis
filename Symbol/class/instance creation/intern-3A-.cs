intern: aStringOrSymbol 

	(aStringOrSymbol class == MultiString
			and: [aStringOrSymbol isOctetString not])
		ifTrue: [^ MultiSymbol intern: aStringOrSymbol].
	^ (self lookup: aStringOrSymbol)
		ifNil: [NewSymbols
				add: ((aStringOrSymbol isKindOf: Symbol)
						ifTrue: [aStringOrSymbol]
						ifFalse: [(self new: aStringOrSymbol size)
								string: aStringOrSymbol])].
