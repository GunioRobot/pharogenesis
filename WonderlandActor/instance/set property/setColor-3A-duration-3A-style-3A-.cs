setColor: newColor duration: time style: aStyle
	"Set the actor's color"

	| anim aColor |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyColor: newColor ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what color to make ' , myName , ' because ', msg.
			^ nil ].


	[ WonderlandVerifier VerifyDuration: time ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for changing the color of ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use for changing the color of ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	((newColor at: 1) isNumber)
				ifTrue: [ aColor _ B3DColor4 red: (newColor at: 1) green: (newColor at: 2)
										blue: (newColor at: 3) alpha: (myColor alpha) ]
				ifFalse: [ aColor _ Color perform: newColor.
						  aColor _ B3DColor4 red: (aColor red) green: (aColor green)
										blue: (aColor blue) alpha: (myColor alpha) ].

	anim _ AbsoluteAnimation new.
	anim object: self
			update: [:tColor | self setColorVector: tColor]
			getStartState: [self getColorVector]
			getEndState: [ aColor ]
			style: aStyle
			duration: time
			undoable: true
			inWonderland: myWonderland.

	^ anim.
