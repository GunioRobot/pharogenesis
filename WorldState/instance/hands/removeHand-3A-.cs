removeHand: aHandMorph
	"Remove the given hand from the list of hands for this world."

	(hands includes: aHandMorph) ifFalse: [^self].
	hands _ hands copyWithout: aHandMorph.
	activeHand == aHandMorph ifTrue: [activeHand _ nil].
