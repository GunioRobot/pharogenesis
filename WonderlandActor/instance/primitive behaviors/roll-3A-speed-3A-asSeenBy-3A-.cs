roll: aDirection speed: aSpeed asSeenBy: reference
	"Creates and returns an action that rolls the object in the specified direction at the specified speed."

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to roll ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to roll ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can not roll ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

	^ self doEachFrame: [
				self rollRightNow: aDirection
				numberOfTurns: ((myWonderland getScheduler getElapsedTime) * aSpeed)
				asSeenBy: reference
				undoable: false
						].
