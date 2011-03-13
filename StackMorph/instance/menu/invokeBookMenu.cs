invokeBookMenu
	"Invoke the book's control panel menu."
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Stack'.
	aMenu addStayUpItem.
	aMenu addList: #(
		('find...'								textSearch)
		('show designations' 					showDesignationsOfObjects)
		('explain designations'					explainDesignations)
		('look inside'							openInsideLook)
		-
		('previous card' 						goToPreviousCardInStack)
		('next card' 							goToNextCardInStack)
		('first card' 							goToFirstCardOfStack)
		('last card' 								goToLastCardOfStack)
		('go to card...' 							goToCard)
		-
		('add a card of this background' 		insertCard)
		('add a card of background...'		 	insertCardOfBackground)
		('make a new background...' 			makeNewBackground)
		-
		('delete this card' 						deleteCard)
		-
		('scripts for this background'			browseCardClass)
		-
		('debug...'								offerStackDebugMenu)
		('bookish items...' 						offerBookishMenu)).
	aMenu addUpdating: #showingPageControlsString action: #toggleShowingOfPageControls.

	aMenu popUpEvent: self world activeHand lastEvent in: self world


