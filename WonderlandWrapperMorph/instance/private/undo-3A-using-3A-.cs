undo: anUndoClass using: aValue
	"Check if we need to add an undo action."
	myWonderland getUndoStack push: (anUndoClass for: myActor from: aValue).