angularDistanceTo: aRotationVector
	"Returns the angular distance in degrees between the actor's current orientation and an (x, y, z) rotation vector"

	| m sum angles vector1 vector2 |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTarget: aRotationVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can only calculate the distance from ' , myName , ' to an actor or 3D point.'.
			^ nil ].

	"Our arguments check out, so determine the distance"
	m _ B3DMatrix4x4 identity.
	m rotation: (self getRotationVector).

	m _ m composeWith: (B3DMatrix4x4 identity translation: (B3DVector3 x:0 y:0 z:1)).
	vector1 _ m translation.

	m setIdentity.

	(aRotationVector isKindOf: WonderlandActor)
		ifTrue: [
				angles _ aRotationVector getAngles: myParent.
				m rotation: (B3DVector3 x: (angles at: 1) y: (angles at: 2) z: (angles at: 3)).
				]
		ifFalse: [
				m rotation: (B3DVector3 x: (aRotationVector at: 1) y: (aRotationVector at: 2)
										z: (aRotationVector at: 3)).
				].

	m _ m composeWith: (B3DMatrix4x4 identity translation: (B3DVector3 x:0 y:0 z:1)).
	vector2 _ m translation.

	sum _ ((vector1 x) * (vector2 x)) + ((vector1 y) * (vector2 y)) + ((vector1 z) * (vector2 z)).

	^ ((sum / ((vector1 length) * (vector2 length))) arcCos) radiansToDegrees.
