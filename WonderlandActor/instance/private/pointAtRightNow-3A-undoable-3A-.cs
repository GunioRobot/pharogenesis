pointAtRightNow: aTarget undoable: isUndoable
	"Turn this object to the specified orientation instantaneously"

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoRotationChange for: self from: (self getAngles)).
						].

	self setRotationMatrix: (self getPointAtMatrix: aTarget).


