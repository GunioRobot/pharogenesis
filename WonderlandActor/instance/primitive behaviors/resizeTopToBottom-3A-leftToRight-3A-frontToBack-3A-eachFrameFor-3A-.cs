resizeTopToBottom: height leftToRight: width frontToBack: thickness eachFrameFor: aLifetime
	"Resize the object by the specified amount each frame for the specified lifetime."

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

	[ WonderlandVerifier VerifyNonNegativeNumber: aLifetime ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how long it should resize ' , myName , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).

	^ self doEachFrame: [ self resizeRightNow: (B3DVector3 x: width y: height z: thickness)
									undoable: false ]
			for: aLifetime.