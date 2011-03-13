getCurrentSelectionIndex
	"Answer the index of the current selection."

	getSelectionSelector == nil ifTrue: [^ 0].
	^ model perform: getSelectionSelector