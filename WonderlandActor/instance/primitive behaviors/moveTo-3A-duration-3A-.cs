moveTo: aVector duration: aDuration
	"Moves the object to the specified position in its parent's coordinate system over the specified duration using the Gently animation style."


	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to move ' , myName , ' to because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyDuration: aDuration ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the duration to use for moving ' , myName , ' because ', msg.
				^ nil ].

		self moveToRightNow: aVector undoable: true.
		^ self. ].

	(aDuration = eachFrame) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to move ' , myName , ' to because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyDuration: aDuration ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the duration to use for moving ' , myName , ' because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self moveToRightNow: aVector	undoable: false ].
									].

	^ (self moveTo: aVector duration: aDuration
			style: gently).
