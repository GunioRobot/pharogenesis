flagAttributes: attributeSymbolList
	"Mark the receiver has being flagged with all the symbols in the list provided"

	attributeSymbolList do: [:aSym | self flagAttribute: aSym]