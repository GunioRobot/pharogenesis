invokeBookMenu
	"Answer a menu to be popped up from the book-control panel"
	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	#(
		"	('border color...' 		changeBorderColor:)
			('border width...' 		changeBorderWidth:)
			('lock'					lock)"
			('make bookmark'		bookmarkForThisPage)
			('sort pages'				sortPages:)
			('remove control panel'	deleteControls)
		).
	(self primaryHand classOfPasteBuffer isKindOf: PasteUpMorph class) ifTrue:
		[aMenu add: 'paste book page'	action: #pasteBookPage].

	aMenu add: 'save as new-page prototype' action: #setNewPagePrototype.
	newPagePrototype ifNotNil: [
		aMenu add: 'clear new-page prototype' action: #clearNewPagePrototype].

	aMenu add: (openToDragNDrop ifTrue: ['close'] ifFalse: ['open']) , ' dragNdrop'
			action: #openCloseDragNDrop.

	aMenu invokeOn: self defaultSelection: nil