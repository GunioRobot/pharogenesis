initializeWith: anActionorAnimation in: aStack
	"Initialize this instance"

	stoppableItem _ anActionorAnimation.
	myUndoStack _ aStack.
