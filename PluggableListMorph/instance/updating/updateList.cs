updateList
	| index |
	"the list has changed -- update from the model"
	self listMorph listChanged.
	self setScrollDeltas.
	scrollBar setValue: 0.0.
	index _ self getCurrentSelectionIndex.
	self resetPotentialDropRow.
	self selectionIndex: index.
