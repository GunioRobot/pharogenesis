setSizeRightNow: aVector undoable: isUndoable
	"Set this object's size instantaneously"

	| meshSize |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).
						].

	meshSize _ self getBoundingBox extent.

	"Now make sure we don't accidentally divide by zero"
	((meshSize x) = 0) ifTrue: [ aVector at: 1 put: 1.
							    meshSize x: 1 ].

	((meshSize y) = 0) ifTrue: [ aVector at: 2 put: 1.
							    meshSize y: 1 ].

	((meshSize z) = 0) ifTrue: [ aVector at: 3 put: 1.
							    meshSize z: 1 ].

	^ self scaleByVector: (B3DVector3 x: ((aVector at: 1) / (meshSize x))
									y: ((aVector at: 2) / (meshSize y))
									z: ((aVector at: 3) / (meshSize z)) ).


