place: aLocation object: aTarget duration: aDuration 
	"Moves this object to one of several pre-determined locations relative to the target object."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyLocation: aLocation ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyActor: aTarget ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
				^ nil ].

		self placeRightNow: aLocation object: aTarget undoable: true.
		^ self. ].

	(aDuration = eachFrame) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyLocation: aLocation ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyActor: aTarget ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self placeRightNow: aLocation object: aTarget undoable: false ].
									].

	 ^ self place: aLocation object: aTarget duration: aDuration style: gently.
