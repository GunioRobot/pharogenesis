prologue: currentTime
	"This method performs any actions that need to be done before the parallel animation starts."

	super prologue: currentTime.

	undoable ifTrue: [
						(myWonderland getUndoStack)
								push: (UndoAnimation new: (self makeUndoVersion)).
					].

	children do: [:child | child prologue: currentTime. ].

	(direction = Reverse) ifTrue: [ children do: [:child | child pause ] ].
