privateMoveBy: delta
	"Private! Use 'position:' instead."

	fullBounds == bounds ifTrue: [
		"optimization: avoids recomputing fullBounds"
		fullBounds _ bounds _ bounds translateBy: delta.
	] ifFalse: [
		bounds _ bounds translateBy: delta.
		fullBounds _ nil].
