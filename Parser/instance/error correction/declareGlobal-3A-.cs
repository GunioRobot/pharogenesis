declareGlobal: name
	| sym |
	sym _ name asSymbol.
	Smalltalk at: sym put: nil.
	^ encoder global: (Smalltalk associationAt: sym) name: sym