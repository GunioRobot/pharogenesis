colorForType: typeSymbol

	^ (ColorsForType
		at: typeSymbol asSymbol
		ifAbsent: [^ Color magenta]) at: 1
