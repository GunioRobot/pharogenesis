changeModelSelection: anInteger
	"Change the model's selected item index to be anInteger."

	setIndexSelector ifNotNil:
		[model perform: setIndexSelector with: anInteger].