setPrecisionFor: slotName 
	"Set the precision for the given slot name"

	| aList aMenu reply val aGetter places |
	aGetter := Utilities getterSelectorFor: slotName.
	places := Utilities 
				decimalPlacesForFloatPrecision: (self defaultFloatPrecisionFor: aGetter).
	aList := #('0' '1' '2' '3' '4' '5' '6').
	aMenu := SelectionMenu labels: aList
				selections: (aList collect: [:m | m asNumber]).
	reply := aMenu 
				startUpWithCaption: ('How many decimal places? (currently {1})' translated
						format: {places}).
	reply ifNotNil: 
			[(self slotInfo includesKey: slotName) 
				ifTrue: 
					["it's a user slot"

					(self slotInfoAt: slotName) 
						floatPrecision: (Utilities floatPrecisionForDecimalPlaces: reply).
					self class allInstancesDo: 
							[:anInst | 
							reply == 0 
								ifFalse: 
									[((val := anInst instVarNamed: slotName asString) isInteger) 
										ifTrue: [anInst instVarNamed: slotName asString put: val asFloat]].
							anInst updateAllViewers]]
				ifFalse: 
					["it's specifying a preference for precision on a system-defined numeric slot"

					self noteDecimalPlaces: reply forGetter: aGetter.
					self updateAllViewers]]