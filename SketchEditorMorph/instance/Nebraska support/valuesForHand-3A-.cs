valuesForHand: anEventOrHand

	| hand valuesForHand |
	forEachHand ifNil: [forEachHand _ IdentityDictionary new].
	hand _ (anEventOrHand isKindOf: HandMorph) 
				ifTrue: [anEventOrHand] ifFalse: [anEventOrHand hand].
	valuesForHand _ forEachHand at: hand ifAbsentPut: [Dictionary new].
	^valuesForHand

