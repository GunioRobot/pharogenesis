makeCurrentCardLastInStack
	"Move the current card such that it becomes the last card in the stack"

	| aCard |
	aCard _ self currentCard.
	self privateCards remove: aCard ifAbsent: [];
		addLast: aCard.
	self currentPage flash