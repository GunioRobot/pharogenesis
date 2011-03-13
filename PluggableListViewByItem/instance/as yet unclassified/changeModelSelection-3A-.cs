changeModelSelection: anInteger
	"Change the model's selected item to be the one at the given index."
	| item |
	setSelectionSelector ifNotNil: [
		item := (anInteger = 0 ifTrue: [nil] ifFalse: [itemList at: anInteger]).
		model perform: setSelectionSelector with: item].
