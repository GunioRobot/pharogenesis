getCurrentSelectionIndex
	"Answer the index of the current selection."

	| item |
	getSelectionSelector == nil ifTrue: [^ 0].
	item _ model perform: getSelectionSelector.
	^ items findFirst: [ :x | x = item]
