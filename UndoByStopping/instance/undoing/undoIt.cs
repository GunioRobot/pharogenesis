undoIt
	"Undo by stopping the stoppable item"

	(stoppableItem isDone) ifTrue: [ myUndoStack popAndUndo ]
						   ifFalse: [ stoppableItem stop ].

