removeSelection
	"Remove the current selection from the model"

	model selectionIndex = 0
		ifTrue: [^view flash].
	^ model removeSelection