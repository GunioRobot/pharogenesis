rollRightNow: aDirection numberOfTurns: numTurns asSeenBy: reference undoable: isUndoable
	"Turn the object instantaneously the specified number of turns in the specified direction"

	| tMatrix degrees  newMatrix |

	tMatrix _ B3DMatrix4x4 identity.
	degrees _ 360 * numTurns.

	(isUndoable = true) ifTrue: [
		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).
						].

	(aDirection = left) ifTrue: [ tMatrix rotationAroundZ: degrees ]
	ifFalse: [(aDirection = right) ifTrue: [ tMatrix rotationAroundZ: (degrees negated) ]
								ifFalse: [ myWonderland reportErrorToUser: 'Squeak does not know how to roll ' , myName , ' ', (aDirection asString) , '.'.
										^ nil ]].

	newMatrix _ reference getMatrixToRoot.
	newMatrix _ newMatrix composeWith: (self getMatrixFromRoot).
	composite _ (((myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot))
											composeWith: tMatrix)
											composeWith: newMatrix.
