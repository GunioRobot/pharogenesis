getPointOfView: reference
	"Returns the object's position and orientation"

	| newComposite anArray a3DVector |

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can determine the point of view of ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	newComposite _ reference getMatrixToRoot.
	newComposite _ newComposite composeWith: (self getMatrixFromRoot).

	a3DVector _ newComposite translation.

	anArray _ Array new: 6.
	anArray at: 1 put: (a3DVector x).
	anArray at: 2 put: (a3DVector y).
	anArray at: 3 put: (a3DVector z).

	a3DVector _ newComposite rotation.
	anArray at: 4 put: (a3DVector x).
	anArray at: 5 put: (a3DVector y).
	anArray at: 6 put: (a3DVector z).

	^ anArray.
