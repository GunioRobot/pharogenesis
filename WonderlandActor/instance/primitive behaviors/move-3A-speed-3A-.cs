move: aDirection speed: aSpeed
	"Creates and returns an action that moves the object in the specified direction at the specified speed."

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to move ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to move ' , myName , ' at because ', msg.
			^ nil ].

	"The parameters check out, so go ahead and start the action"
	myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

	^ self doEachFrame: [ self moveRightNow: aDirection
							distance: ((myWonderland getScheduler getElapsedTime) * aSpeed)
							undoable: false ].
