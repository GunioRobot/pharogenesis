addMagicHaloFor: aHand
	| halo prospectiveHaloClass |
	aHand halo ifNotNil:[
		aHand halo target == self ifTrue:[^self].
		aHand halo isMagicHalo ifFalse:[^self]].
	prospectiveHaloClass := Smalltalk at: self haloClass ifAbsent: [HaloMorph].
	halo := prospectiveHaloClass new bounds: self worldBoundsForHalo.
	halo popUpMagicallyFor: self hand: aHand.