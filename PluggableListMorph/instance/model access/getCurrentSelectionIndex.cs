getCurrentSelectionIndex
	"Answer the index of the current selection."

	getIndexSelector isNil ifTrue: [^0].
	^model perform: getIndexSelector