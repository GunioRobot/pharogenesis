addMagicHaloFor: aHand
	| halo prospectiveHaloClass |
	aHand halo ifNotNil:[
		aHand halo target == self ifTrue:[^self].
		aHand halo isMagicHalo ifFalse:[^self]].
	prospectiveHaloClass _ Smalltalk at: self haloClass ifAbsent: [HaloMorph].
	halo _ prospectiveHaloClass new bounds: self worldBoundsForHalo.
	halo popUpMagicallyFor: self hand: aHand.