removeHand: aHandMorph
	"Remove the given hand from the list of hands for this world."

	(hands includes: aHandMorph) ifFalse: [^self].
	hands _ hands copyWithout: aHandMorph.
	ActiveHand == aHandMorph ifTrue: [ActiveHand _ nil].
