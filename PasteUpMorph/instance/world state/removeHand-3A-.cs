removeHand: aHandMorph
	"Remove the given hand from the list of hands for this world."

	(self hands includes: aHandMorph) ifTrue: [
		aHandMorph dropMorphsEvent: MorphicEvent new.
		self hands: (self hands copyWithout: aHandMorph).
		self invalidRect: aHandMorph fullBounds.
		self activeHand == aHandMorph ifTrue: [self activeHand: nil]].
