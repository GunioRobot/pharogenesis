getAngles: reference
	"Returns the object's orientation relative to a reference object"

	| newComposite anArray a3DVector |

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can not determine the angles of ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	newComposite _ reference getMatrixToRoot.
	a3DVector _ (newComposite composeWith: (self getMatrixFromRoot)) rotation.

	anArray _ Array new: 3.
	anArray at: 1 put: (a3DVector x).
	anArray at: 2 put: (a3DVector y).
	anArray at: 3 put: (a3DVector z).

	^ anArray.
