moveTo: aPoint duration: aDuration style: aStyle
	"Moves the object to the specified position in its parent's coordinate system using the specified style over the specified duration."

	| anim |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyPoint: aPoint ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to move the morph to because ', msg.
			^ nil ].


	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for moving the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to move the morph because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	anim object: self
			update: [:tPos | self position: (tPos rounded)]
			getStartState: [self position]
			getEndState: [ aPoint ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
