getCurrentSelectionIndex
	"Answer the index of the current selection."

	getIndexSelector == nil ifTrue: [^ 0].
	^ model perform: getIndexSelector