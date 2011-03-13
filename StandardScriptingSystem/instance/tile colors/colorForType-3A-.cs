colorForType: typeSymbol
	"Answer the color to use to represent the given type symbol"

	^ ((TypeColorDictionary
		at: typeSymbol asSymbol
		ifAbsent: [^ Color magenta muchLighter]) at: 1) lighter
