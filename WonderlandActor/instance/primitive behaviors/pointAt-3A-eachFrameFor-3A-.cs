pointAt: target eachFrameFor: aLifetime
	"Turns the object to point at the specified target each frame for the specified lifetime."

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTargetOrPixel: target ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what to point ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNonNegativeNumber: aLifetime ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how long it should point ' , myName , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

	^ self doEachFrame: [ self pointAtRightNow: target undoable: false ]
			for: aLifetime.
