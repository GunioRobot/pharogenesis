resetStacks
	| card stackStream stack |

	stacks do: [:deck | deck removeAllCards].
	stackStream _ ReadStream on: stacks.
	[card _ cardDeck deal.
	card notNil] whileTrue: [
		stack _ stackStream next ifNil: [stackStream reset; next].
		stack addCard: card].
