changeModelSelection: anInteger
	"Change the model's selected item to be the one at the given index."

	| item |
	setSelectionSelector ~~ nil ifTrue: [
		item _ (anInteger = 0 ifTrue: [nil] ifFalse: [items at: anInteger]).
		model perform: setSelectionSelector with: item.
		getSelectionSelector == nil ifFalse: [model perform: getSelectionSelector].
	].