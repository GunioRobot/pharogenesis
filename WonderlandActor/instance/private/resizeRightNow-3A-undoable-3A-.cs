resizeRightNow: aVector undoable: isUndoable
	"Set this object's size instantaneously"

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).
						].

	self scaleByVector: aVector.
