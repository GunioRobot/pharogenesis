redoMove
	"Redo the last undone move"
	redoList isEmpty ifTrue:[^self].
	board nextMove: redoList removeLast.
