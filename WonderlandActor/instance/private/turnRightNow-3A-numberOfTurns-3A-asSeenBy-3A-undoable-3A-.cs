turnRightNow: aDirection numberOfTurns: numTurns asSeenBy: reference undoable: isUndoable
	"Turn the object instantaneously the specified number of turns in the specified direction"

	| tMatrix degrees  newMatrix |

	tMatrix _ B3DMatrix4x4 identity.
	degrees _ 360 * numTurns.

	(isUndoable = true) ifTrue: [
		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).
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

	newMatrix _ reference getMatrixToRoot.
	newMatrix _ newMatrix composeWith: (self getMatrixFromRoot).
	composite _ (((myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot))
											composeWith: tMatrix)
											composeWith: newMatrix.

