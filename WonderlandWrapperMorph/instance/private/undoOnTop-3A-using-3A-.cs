undoOnTop: anUndoClass using: aBlock
	"Check if we need to add an undo action."
	| stack top |
	stack _ myWonderland getUndoStack.
	top _ stack top.
	((top isKindOf: anUndoClass) and:[top getActor == myActor]) ifFalse:[
		stack push: (anUndoClass for: myActor from: aBlock value)].
