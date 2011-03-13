changeModelSelection: anInteger 
	"Change the model's selected item to be the one at the given index."
	| item |
	setIndexSelector
		ifNotNil: [item _ anInteger = 0
						ifFalse: [itemList at: anInteger].
			model perform: setIndexSelector with: item].
	self update: getIndexSelector