prologue: currentTime
	"Overrides the Animation prologue: message to set the index of the current animation to 1"

	super prologue: currentTime.

	undoable ifTrue: [
						(myWonderland getUndoStack)
								push: (UndoAnimation new: (self makeUndoVersion)).
					].

	index _ 1.
	((children size) > 0) ifTrue: [(children at: index) prologue: currentTime.]
						ifFalse: [ state _ Finished. ].
