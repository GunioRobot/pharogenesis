place: aLocation object: aTarget eachFrameUntil: aCondition
	"Moves this object to one of several pre-determined locations relative to the target object each frame for the specified lifetime."

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyLocation: aLocation ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyActor: aTarget ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyCondition: aCondition ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine for how long it should place ' , myName , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

	^ self doEachFrame: [ self placeRightNow: aLocation object: aTarget undoable: false ]
			until: aCondition.
