brightColorForType: typeSymbol
	^ (TypeColorDictionary
		at: typeSymbol asSymbol
		ifAbsent: [^ Color magenta]) at: 2
