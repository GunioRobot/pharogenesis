moveCardOnePositionEarlier
	"Move the current card such that its ordinal position is one fewer than it formerly was.  If the current card is already the first one one in the stack, then do nothing"

	| aCard aPosition |
	aCard _ self currentCard.
	aCard == self privateCards first ifTrue: [^ self].
	aPosition _ self privateCards indexOf: aCard.
	self privateCards remove: aCard;
		add: aCard afterIndex: (aPosition - 2).
	self currentPage flash