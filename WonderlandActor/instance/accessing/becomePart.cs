becomePart
	"Make the actor a part."

	firstClass _ false.

	(myWonderland getUndoStack) push: (UndoAction new: [ firstClass _ true ]).
