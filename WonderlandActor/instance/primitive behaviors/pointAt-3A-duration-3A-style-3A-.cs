pointAt: target duration: aDuration style: aStyle
	"Turns the object to point at the specified target using the specified style over the specified duration."

	| anim |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTargetOrPixel: target ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what to point ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for pointing ' , myName , ' at ' , (target asString) , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to point ' , myName , ' because ', msg.
			^ nil ].

	"The parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	anim object: self
			update: [:tQuat | self setRotationMatrix: (tQuat asMatrix4x4) ]
			getStartState: [ composite asQuaternion ]
			getEndState: [ (self getPointAtMatrix: target) asQuaternion ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
