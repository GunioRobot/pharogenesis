new: anAction
	"Create a wrapper for undoing an animation"

	| newUndo |

	newUndo _ UndoAction new.
	newUndo setAction: anAction.
	^ newUndo.