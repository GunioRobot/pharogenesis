removeHand: aHandMorph
	"Remove the given hand from the list of hands for this world."

	(hands includes: aHandMorph) ifTrue: [
		aHandMorph dropMorphsEvent: MorphicEvent new.
		hands _ hands copyWithout: aHandMorph].
