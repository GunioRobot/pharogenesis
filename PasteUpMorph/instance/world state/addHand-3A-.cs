addHand: aHandMorph
	"Add the given hand to the list of hands for this world."

	self hands: (self hands copyWith: aHandMorph).
	aHandMorph privateOwner: self.
