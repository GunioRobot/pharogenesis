makeCurrentCardFirstInStack
	"Move the current card such that it becomes the first card in the stack"

	| aCard |
	aCard _ self currentCard.
	self privateCards remove: aCard ifAbsent: [];
		addFirst: aCard.
	self currentPage flash