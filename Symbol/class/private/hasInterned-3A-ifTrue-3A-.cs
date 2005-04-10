hasInterned: aString ifTrue: symBlock 
	"Answer with false if aString hasnt been interned (into a Symbol),  
	otherwise supply the symbol to symBlock and return true."

	| symbol |
	^ (symbol _ self lookup: aString)
		ifNil: [false]
		ifNotNil: [symBlock value: symbol.
			true]