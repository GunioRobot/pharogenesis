setColorRightNow: newColor undoable: isUndoable
	"Change this instance's color instantaneously"

	| aColor |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoColorChange for: self from: (self getColor)) ].

	((newColor at: 1) isNumber)
				ifTrue: [ aColor _ B3DColor4 red: (newColor at: 1) green: (newColor at: 2)
										blue: (newColor at: 3) alpha: (1.0) ]
				ifFalse: [ aColor _ Color perform: newColor.
						  aColor _ B3DColor4 red: (aColor red) green: (aColor green)
										blue: (aColor blue) alpha: (1.0) ].

	self setColorVector: aColor.
