pickGame: aSeedOrNil
	cardDeck _ PlayingCardDeck newDeck.
	aSeedOrNil ifNotNil:[cardDeck seed: aSeedOrNil].
	cardDeck shuffle.
	self resetBoard