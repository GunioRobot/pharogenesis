declareClassVar: name
	| sym class |
	sym := name asSymbol.
	class := encoder classEncoding.
	class := class theNonMetaClass.		"not the metaclass"
	class addClassVarName: name.
	^ encoder global: (class classPool associationAt: sym)
			name: sym