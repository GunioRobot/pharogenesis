turnToRightNow: aVector asSeenBy: reference undoable: isUndoable
	"Turn this object to the specified orientation instantaneously"

	| m angles newComposite |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoRotationChange for: self from: (self getAngles)).
						].

	m _ B3DMatrix4x4 identity.
	angles _ self getAngles: reference.
	((aVector at: 1) = asIs) ifFalse: [ angles at: 1 put: (aVector at: 1) ].
	((aVector at: 2) = asIs) ifFalse: [ angles at: 2 put: (aVector at: 2) ].
	((aVector at: 3) = asIs) ifFalse: [ angles at: 3 put: (aVector at: 3) ].
	m rotation: (B3DVector3 x: (angles at: 1) y: (angles at: 2) z: (angles at: 3)).
	newComposite _ (myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot).
	self setRotationMatrix: (newComposite composeWith: m).


