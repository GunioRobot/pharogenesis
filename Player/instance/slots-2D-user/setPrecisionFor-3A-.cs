setPrecisionFor: slotName
	| aList aMenu reply precision val |
	aList _ #('0' '1' '2' '3' '4' '5').
	aMenu _ SelectionMenu labels: aList selections: aList.
	reply _ aMenu startUpWithCaption: 'How many decimal places?'.
	reply ifNotNil:
		[(self slotInfoAt: slotName) floatPrecision:
			(precision _ #(1 0.1 0.01 0.001 0.0001 0.00001 0.000001) at: (aList indexOf: reply)).
		self class allInstancesDo:   "allSubInstancesDo:"
			[:anInst |
				precision ~= 1 ifTrue:
					[((val _ anInst instVarNamed: slotName asString) isKindOf: Integer)
						ifTrue:
							[anInst instVarNamed: slotName asString put: val asFloat]].
				anInst updateAllViewers]]
