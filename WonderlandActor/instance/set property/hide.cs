hide
	"Tell the object that it should not draw itself each frame"

	(myWonderland getUndoStack) push: (UndoShowHide undoHideFor: self).

	self setHidden: true.
