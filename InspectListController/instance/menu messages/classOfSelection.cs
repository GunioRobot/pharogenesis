classOfSelection
	"Answer the class of the receiver's current selection.  1/25/96 sw"

	model selectionUnmodifiable ifTrue: [^ model object class].
	^ model selection class