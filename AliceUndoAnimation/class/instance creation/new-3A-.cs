new: anAnimation
	"Create a wrapper for undoing an animation"

	| newUndo |

	newUndo _ UndoAnimation new.
	newUndo setAnimation: anAnimation.
	^ newUndo.