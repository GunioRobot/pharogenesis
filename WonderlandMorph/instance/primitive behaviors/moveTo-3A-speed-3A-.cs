moveTo: aPoint speed: aSpeed
	"Moves the object to the specified position in its parent's coordinate system at the specified speed."

	| anim |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyPoint: aPoint ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to move the morph to because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the speed to move the morph because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	anim object: self
			update: [:tPos | self position: (tPos rounded)]
			getStartState: [self position]
			getEndState: [ aPoint ]
			style: abruptly
			duration: ((self position) dist: aPoint) / aSpeed
			undoable: true
			inWonderland: myWonderland.

	^ anim.
