moveToRightNow: aVector asSeenBy: reference undoable: isUndoable
	"Move this object in the specified direction instantaneously"

	| pos aMatrix newComposite |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoPositionChange for: self from: (self getPosition)).
						].

	aMatrix _ B3DMatrix4x4 identity.
	pos _ self getPosition: reference.
	((aVector at: 1) = asIs) ifFalse: [ pos at: 1 put: (aVector at: 1) ].
	((aVector at: 2) = asIs) ifFalse: [ pos at: 2 put: (aVector at: 2) ].
	((aVector at: 3) = asIs) ifFalse: [ pos at: 3 put: (aVector at: 3) ].
	aMatrix translation: (B3DVector3 x: (pos at: 1) y: (pos at: 2) z: (pos at: 3)).
	newComposite _ (myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot).
	newComposite _ newComposite composeWith: aMatrix.
		newComposite translation.
	self setPositionVector: (newComposite translation).

