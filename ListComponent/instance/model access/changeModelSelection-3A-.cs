changeModelSelection: anInteger
	"Change the model's selected item index to be anInteger."

	setIndexSelector
		ifNil: 	["If model is not hooked up to index, then we won't get
					an update, so have to do it locally."
				self selectionIndex: anInteger]
		ifNotNil: [model perform: setIndexSelector with: anInteger].
	selectedItem _ anInteger = 0 ifTrue: [nil] ifFalse: [self getListItem: anInteger].
	setSelectionSelector ifNotNil:
		[model perform: setSelectionSelector with: selectedItem]