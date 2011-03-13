goToPreviousCardInStack
	"Install the previous card as my current one"

	| anIndex newCard |
	anIndex _ cards indexOf: currentPage currentDataInstance.
	newCard _ cards atWrap: anIndex - 1.
	self goToCard: newCard