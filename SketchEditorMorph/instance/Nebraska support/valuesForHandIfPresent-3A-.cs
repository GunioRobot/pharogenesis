valuesForHandIfPresent: anEventOrHand

	| hand |
	forEachHand ifNil: [forEachHand _ IdentityDictionary new].
	hand _ (anEventOrHand isKindOf: HandMorph) 
				ifTrue: [anEventOrHand] ifFalse: [anEventOrHand hand].
	^forEachHand at: hand ifAbsent: [nil].

