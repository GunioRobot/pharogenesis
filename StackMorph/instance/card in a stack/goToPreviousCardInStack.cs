goToPreviousCardInStack
	"Install the previous card as my current one"

	| anIndex newCard |
	anIndex _ self privateCards indexOf: currentPage currentDataInstance.
	newCard _ self privateCards atWrap: anIndex - 1.
	self goToCard: newCard