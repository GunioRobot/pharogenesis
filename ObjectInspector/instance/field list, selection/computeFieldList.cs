computeFieldList
	"Answer the base field list plus an abbreviated list of indices."
	fieldList _ (Array with: 'self') , object class allInstVarNames.
	object class isVariable ifFalse: [^ fieldList].
	^ fieldList ,
		((object basicSize <= (self nLow + self nHigh) or: [showAllIndices])
			ifTrue: [(1 to: object basicSize)
						collect: [:i | i printString]]
			ifFalse: [(1 to: self nLow) , #('...') , (object basicSize-(self nHigh-1) to: object basicSize)
						collect: [:i | i printString]])