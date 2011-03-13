declareClassVar: name
	| sym class |
	sym _ name asSymbol.
	class _ encoder classEncoding.
	class _ class theNonMetaClass.		"not the metaclass"
	class addClassVarName: name.
	^ encoder global: (class classPool associationAt: sym)
			name: sym