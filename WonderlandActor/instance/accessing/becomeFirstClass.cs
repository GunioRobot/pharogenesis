becomeFirstClass
	"Make the actor a first class object."

	firstClass _ true.

	(myWonderland getUndoStack) push: (UndoAction new: [ firstClass _ false ]).
