intern: aStringOrSymbol
	^(SymbolTable like: aStringOrSymbol)
		ifNil:
			[
				SymbolTable add:
					((aStringOrSymbol isKindOf: Symbol)
						ifTrue: [aStringOrSymbol]
						ifFalse: [(self new: aStringOrSymbol size) string: aStringOrSymbol])
			]