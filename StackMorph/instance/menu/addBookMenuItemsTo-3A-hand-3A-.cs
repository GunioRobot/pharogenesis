addBookMenuItemsTo: aMenu hand: aHandMorph
	"Add book-related items to the given menu"

	| controlsShowing subMenu |
	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'previous card' action: #goToPreviousCardInStack.
	subMenu add: 'next card' action: #goToNextCardInStack.
	subMenu add: 'go to card...' action: #goToCard.
	subMenu add: 'insert a card' action: #insertCard.
	subMenu add: 'delete this card' action: #deleteCard.

	controlsShowing _ self hasSubmorphWithProperty: #pageControl.
	controlsShowing
		ifTrue:
			[subMenu add: 'hide card controls' action: #hidePageControls.
			subMenu add: 'fewer card controls' action: #fewerPageControls]
		ifFalse:
			[subMenu add: 'show card controls' action: #showPageControls].

	subMenu addLine.
	subMenu add: 'sound effect for all backgrounds' action: #menuPageSoundForAll:.
	subMenu add: 'sound effect this background only' action: #menuPageSoundForThisPage:.
	subMenu add: 'visual effect for all backgrounds' action: #menuPageVisualForAll:.
	subMenu add: 'visual effect this background only' action: #menuPageVisualForThisPage:.

	subMenu addLine.
	subMenu add: 'sort pages' action: #sortPages:.
	subMenu add: 'uncache page sorter' action: #uncachePageSorter.
	(self hasProperty: #dontWrapAtEnd)
		ifTrue: [subMenu add: 'wrap after last page' selector: #setWrapPages: argument: true]
		ifFalse: [subMenu add: 'stop at last page' selector: #setWrapPages: argument: false].

	subMenu addLine.
	subMenu add: 'search for text' action: #textSearch.
	(self primaryHand pasteBuffer class isKindOf: PasteUpMorph class) ifTrue:
		[subMenu add: 'paste book page'	action: #pasteBookPage].

	subMenu add: 'send all pages to server' action: #savePagesOnURL.
	subMenu add: 'send this page to server' action: #saveOneOnURL.
	subMenu add: 'reload all from server' action: #reload.
	subMenu add: 'copy page url to clipboard' action: #copyUrl.
	subMenu add: 'keep in one file' action: #keepTogether.
	subMenu add: 'save as new-page prototype' action: #setNewPagePrototype.
	newPagePrototype ifNotNil:
		[subMenu add: 'clear new-page prototype' action: #clearNewPagePrototype].

	aMenu add: 'book...' subMenu: subMenu
