turn: aDirection speed: aSpeed asSeenBy: reference
	"Creates and returns an action that turn the object in the specified direction at the specified speed."

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to turn ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to turn ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can not turn ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

	^ self doEachFrame: [
				self turnRightNow: aDirection
				numberOfTurns: ((myWonderland getScheduler getElapsedTime) * aSpeed)
				asSeenBy: reference
				undoable: false
						].
