getUndoStack
	"Returns the Wonderland's undo stack."

	^ myUndoStack ifNil:[myUndoStack _ WonderlandUndoStack new].