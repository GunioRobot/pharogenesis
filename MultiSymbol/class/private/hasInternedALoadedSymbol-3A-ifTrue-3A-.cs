hasInternedALoadedSymbol: aString ifTrue: symBlock 
	"Answer with false if aString hasnt been interned (into a MultiSymbol), 
	otherwise supply the symbol to symBlock and return true."

	| symbol |
	^(symbol _ self lookupForLoadedSymbol: aString)
		ifNil: [false]
		ifNotNil: [symBlock value: symbol. true]
