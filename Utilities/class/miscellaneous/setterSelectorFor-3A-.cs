setterSelectorFor: aName
	"Utilities setterSelectorFor: #elvis"
	^ (('set', (aName asString capitalized)), ':') asSymbol