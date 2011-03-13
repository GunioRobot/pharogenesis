addBookMenuItemsTo: aMenu hand: aHandMorph
	| controlsShowing subMenu |
	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'previous page' action: #previousPage.
	subMenu add: 'next page' action: #nextPage.
	subMenu add: 'goto page' action: #goToPage.
	subMenu add: 'insert a page' action: #insertPage.
	subMenu add: 'delete this page' action: #deletePage.

	controlsShowing _ self hasSubmorphWithProperty: #pageControl.
	controlsShowing
		ifTrue:
			[subMenu add: 'hide page controls' action: #hidePageControls.
			subMenu add: 'fewer page controls' action: #fewerPageControls]
		ifFalse:
			[subMenu add: 'show page controls' action: #showPageControls].
	self isInFullScreenMode ifTrue: [
		subMenu add: 'exit full screen' action: #exitFullScreen.
	] ifFalse: [
		subMenu add: 'show full screen' action: #goFullScreen.
	].
	subMenu addLine.
	subMenu add: 'sound effect for all pages' action: #menuPageSoundForAll:.
	subMenu add: 'sound effect this page only' action: #menuPageSoundForThisPage:.
	subMenu add: 'visual effect for all pages' action: #menuPageVisualForAll:.
	subMenu add: 'visual effect this page only' action: #menuPageVisualForThisPage:.

	subMenu addLine.
	subMenu add: 'sort pages' action: #sortPages:.
	subMenu add: 'uncache page sorter' action: #uncachePageSorter.
	(self hasProperty: #dontWrapAtEnd)
		ifTrue: [subMenu add: 'wrap after last page' selector: #setWrapPages: argument: true]
		ifFalse: [subMenu add: 'stop at last page' selector: #setWrapPages: argument: false].

	subMenu addLine.
	subMenu add: 'search for text' action: #textSearch.
	(aHandMorph pasteBuffer class isKindOf: PasteUpMorph class) ifTrue:
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
