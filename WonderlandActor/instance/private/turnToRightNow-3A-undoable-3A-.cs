turnToRightNow: aVector undoable: isUndoable
	"Turn this object to the specified orientation instantaneously"

	| m angles |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoRotationChange for: self from: (self getAngles)).
						].

	m _ B3DMatrix4x4 identity.

	(aVector isKindOf: WonderlandActor)
		ifTrue: [ angles _ aVector getAngles: myParent.
				  m rotation: (B3DVector3 x: (angles at: 1) y: (angles at: 2) z: (angles at: 3)).
				]
		ifFalse: [ angles _ self getRotationVector.
				  ((aVector at: 1) = asIs) ifFalse: [ angles x: (aVector at: 1) ].
				  ((aVector at: 2) = asIs) ifFalse: [ angles y: (aVector at: 2) ].
				  ((aVector at: 3) = asIs) ifFalse: [ angles z: (aVector at: 3) ].
				  m rotation: angles.
				].

	self setRotationMatrix: m.

