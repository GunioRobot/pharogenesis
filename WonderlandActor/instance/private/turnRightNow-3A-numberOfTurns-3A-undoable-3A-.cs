turnRightNow: aDirection numberOfTurns: numTurns undoable: isUndoable
	"Turn the object instantaneously the specified number of turns in the specified direction"

	| tMatrix degrees  |

	tMatrix _ B3DMatrix4x4 identity.
	degrees _ 360 * numTurns.

	(isUndoable = true) ifTrue: [
		myWonderland getUndoStack push: (UndoRotationChange for: self from: (self getAngles)).
						].

	(aDirection = right) ifTrue: [ tMatrix rotationAroundY: degrees ]
		ifFalse: [(aDirection = left) ifTrue: [ tMatrix rotationAroundY: (degrees negated) ]

		ifFalse: [(((aDirection = up) or: [aDirection = back]) or: [aDirection = backward])
			ifTrue: [ tMatrix rotationAroundX: (degrees negated) ]

		ifFalse: [((aDirection = down) or: [aDirection = forward]) ifTrue: [
			tMatrix rotationAroundX: degrees ]

		ifFalse: [(aDirection = ccw) ifTrue: [ tMatrix rotationAroundZ: degrees ]

		ifFalse: [(aDirection = cw) ifTrue: [ tMatrix rotationAroundZ: (degrees negated) ]

		ifFalse: [ self error: 'Unrecognized direction' ]]]]]].

	self rotateByMatrix: tMatrix.
