setVisibility: newVisibility duration: time style: aStyle
	"Sets the current object's visibility"

	| anim |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier Verify0To1Number: newVisibility ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what visibility to make ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: time ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for changing the visibility of ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use for changing the visibility of ' , myName , ' because ', msg.
			^ nil ].

	anim _ AbsoluteAnimation new.
	anim object: self
			update: [:tColor | self setColorVector: tColor]
			getStartState: [self getColorVector]
			getEndState: [B3DColor4 red: (myColor red) green: (myColor green)
						blue: (myColor blue) alpha: newVisibility]
			style: aStyle
			duration: time
			undoable: true
			inWonderland: myWonderland.


	^ anim.
