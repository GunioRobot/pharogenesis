show
	"Tell the object that it should draw itself each frame"

	(myWonderland getUndoStack) push: (UndoShowHide undoShowFor: self).

	self setHidden: false.
