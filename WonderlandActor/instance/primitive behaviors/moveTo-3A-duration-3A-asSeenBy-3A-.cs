moveTo: aVector duration: aDuration asSeenBy: reference
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

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not move ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

		self moveToRightNow: aVector asSeenBy: reference undoable: true.
		^ self ].

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

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not move ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self moveToRightNow: aVector	asSeenBy: reference undoable: false ].
									].

	^ (self moveTo: aVector duration: aDuration asSeenBy: reference
			style: gently).
