goToNextCardInStack
	"Make the card *after* the current card become the current card"

	| anIndex newCard |
	anIndex _ self privateCards indexOf: currentPage currentDataInstance.
	newCard _ self privateCards atWrap: anIndex + 1.
	self goToCard: newCard