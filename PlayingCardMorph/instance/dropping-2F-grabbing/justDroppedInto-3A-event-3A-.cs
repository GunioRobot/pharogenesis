justDroppedInto: newOwner event: evt

	(newOwner isKindOf: PlayingCardDeck)
		ifFalse: ["Can't drop a card anywhere but on a deck"
				evt hand rejectDropMorph: self event: evt].
