move: aDirection distance: aDistance duration: aDuration style: aStyle
	"Move the actor the specified distance in the specified direction, taking the specified duration and using the specified animation style."

	| anim a3DVector tmpVector tMatrix |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to move ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: aDistance ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the distance to move ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for moving ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to move ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ RelativeAnimation new.
	tmpVector _ (B3DVector3 x:0 y:0 z:0).
	tMatrix _ B3DMatrix4x4 identity.

	[ a3DVector _ self makeVectorFromDistance: aDistance andDirection: aDirection. ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak does not know how to move ' , myName , ' in that direction.'.
			^ nil ].

	anim object: self
			update: [:tPos | composite _ composite composeWith:
												(tMatrix translation: (tPos - tmpVector)).
							tmpVector _ tPos]
			getStartState: [tmpVector x:0; y:0; z:0.
								(B3DVector3 x:0 y:0 z:0) ]
			getEndState: [ a3DVector ]
			getReverseState: [ a3DVector negated ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.

