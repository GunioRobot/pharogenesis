rollRightNow: aDirection numberOfTurns: numTurns undoable: isUndoable
	"Turn the object instantaneously the specified number of turns in the specified direction"

	| tMatrix degrees  |

	tMatrix _ B3DMatrix4x4 identity.
	degrees _ 360 * numTurns.

	(isUndoable = true) ifTrue: [
		myWonderland getUndoStack push: (UndoRotationChange for: self from: (self getAngles)).
						].

	(aDirection = left) ifTrue: [ tMatrix rotationAroundZ: degrees ]
		ifFalse: [(aDirection = right) ifTrue: [ tMatrix rotationAroundZ: (degrees negated) ]
									ifFalse: [ myWonderland reportErrorToUser: 'Squeak does not know how to roll ' , myName , ' ', (aDirection asString) , '.'.
											^ nil ]].

	self rotateByMatrix: tMatrix.
