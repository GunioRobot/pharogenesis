insertCardOfBackground: aBackground
	"Insert a new card of the given background and have it become the current card"

	| newCard |
	newCard _  aBackground newCard.
	self privateCards add: newCard after: self currentCard.
	self goToCard: newCard