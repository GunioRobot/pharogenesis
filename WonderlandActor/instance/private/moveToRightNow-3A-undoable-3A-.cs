moveToRightNow: aVector undoable: isUndoable
	"Move this object in the specified direction instantaneously"

	| pos |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoPositionChange for: self from: (self getPosition)).
						].

	(aVector isKindOf: WonderlandActor)
		ifTrue: [ pos _ aVector getPositionVector ]
		ifFalse: [ pos _ self getPositionVector.
				  ((aVector at: 1) = asIs) ifFalse: [pos x: (aVector at: 1) ].
				  ((aVector at: 2) = asIs) ifFalse: [pos y: (aVector at: 2) ].
				  ((aVector at: 3) = asIs) ifFalse: [pos z: (aVector at: 3) ].
				].

	self setPositionVector: pos.

