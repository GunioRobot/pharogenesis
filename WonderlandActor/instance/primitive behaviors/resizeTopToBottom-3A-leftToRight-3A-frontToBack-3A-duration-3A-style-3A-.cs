resizeTopToBottom: height leftToRight: width frontToBack: thickness duration: aDuration style: aStyle
	"Resize the object by the specified amount over the specified duration."

	| anim tmpVector |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyNumber: height ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from top to bottom because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: width ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from left to right because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: thickness ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from front to back because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for resizing ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to resize ' , myName , ' because ', msg.
			^ nil ].

	"The parameters check out, so build the animation"
	anim _ RelativeAnimation new.
	tmpVector _ B3DVector3 x: 1.0 y: 1.0 z: 1.0.

	anim object: self
			update: [:tScale | self scaleByVector: (tScale / tmpVector).
							tmpVector _ tScale]
			getStartState: [ tmpVector x: 1.0; y: 1.0; z: 1.0.
									(B3DVector3 x: 1.0 y: 1.0 z: 1.0) ]
			getEndState: [ B3DVector3 x: width y: height z: thickness ]
			getReverseState: [ B3DVector3 x: (1 / width) y: (1 / height) z: (1 / thickness) ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
