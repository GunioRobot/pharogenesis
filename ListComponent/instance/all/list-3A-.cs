list: listOfItems
	super list: listOfItems.
	self selectionIndex: 0.
	selectedItem _ nil.
	setSelectionSelector ifNotNil:
		[model perform: setSelectionSelector with: selectedItem]