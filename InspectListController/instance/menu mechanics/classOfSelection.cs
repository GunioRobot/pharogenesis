classOfSelection
	"Answer the class of the receiver's current selection"

	model selectionUnmodifiable ifTrue: [^ model object class].
	^ model selection class