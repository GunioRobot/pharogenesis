invokeBookMenu
	"Answer a menu to be popped up from the book-control panel"
	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	#(
			('border color...' 		changeBorderColor:)
			('border width...' 		changeBorderWidth:)
			('lock'					lock)
			('make bookmark'		bookmarkForThisPage)
			('sort pages'				sortPages:)
			('remove control panel'	deleteControls)
		).
	aMenu add: (openToDragNDrop ifTrue: ['close'] ifFalse: ['open']) , ' dragNdrop'
			action: #openCloseDragNDrop.

	aMenu invokeOn: self defaultSelection: nil