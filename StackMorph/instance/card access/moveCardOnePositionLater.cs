moveCardOnePositionLater
	"Move the current card such that its ordinal position is one greater than it formerly was.  If the current card is already the last one one in the stack, then do nothing"

	| aCard aPosition privateCards |
	aCard _ self currentCard.
	privateCards _ self privateCards.
	aCard == privateCards last ifTrue: [^ self].
	aPosition _ privateCards indexOf: aCard.
	privateCards remove: aCard.
	privateCards add: aCard afterIndex: aPosition.
	self currentPage flash