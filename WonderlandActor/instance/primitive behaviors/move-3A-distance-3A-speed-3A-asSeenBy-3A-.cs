move: aDirection distance: aDistance speed: aSpeed asSeenBy: reference
	"Move the actor the specified distance in the specified direction, taking the specified duration and using the specified animation style."

	| anim a3DVector aDuration tmpVector tMatrix newComposite |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to move ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: aDistance ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the distance to move ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to move ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can not move ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	"The parameters check out, so build the animation"
	anim _ RelativeAnimation new.
	tmpVector _ (B3DVector3 x:0 y:0 z:0).
	tMatrix _ B3DMatrix4x4 identity.

	[ a3DVector _ self makeVectorFromDistance: aDistance andDirection: aDirection. ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak does not know how to move ' , myName , ' in that direction.'.
			^ nil ].

	aDuration _ (aDistance / aSpeed) abs.

	anim object: self
			update: [:tPos | newComposite _ (reference getMatrixToRoot)
										composeWith: (self getMatrixFromRoot).
						 composite _ (((myParent getMatrixToRoot)
										composeWith: (reference getMatrixFromRoot))
										composeWith:
										(tMatrix translation: (tPos - tmpVector)))
										composeWith: newComposite.
						 tmpVector _ tPos]
			getStartState: [tmpVector x:0; y:0; z:0.
								(B3DVector3 x:0 y:0 z:0) ]
			getEndState: [ a3DVector ]
			getReverseState: [ a3DVector negated ]
			style: abruptly
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
