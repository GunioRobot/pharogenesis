goToNextCardInStack
	"Make the card *after* the current card become the current card"

	| anIndex newCard |
	anIndex _ cards indexOf: currentPage currentDataInstance.
	newCard _ cards atWrap: anIndex + 1.
	self goToCard: newCard