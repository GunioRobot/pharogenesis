setVisibilityRightNow: newVisibility undoable: isUndoable
	"Change this instance's visibility instantaneously"

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoVisibilityChange for: self
																 from: (self getVisibility)) ].

	self setColorVector: (B3DColor4 red: (myColor red) green: (myColor green)
						blue: (myColor blue) alpha: newVisibility).
