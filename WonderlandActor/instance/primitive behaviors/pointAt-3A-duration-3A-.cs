pointAt: target duration: aDuration
	"Turns the object to point at the specified target over the specified duration using the Gently animation style."


	(aDuration = rightNow) ifTrue: [
		"Check the target to make sure it's valid"
		[ WonderlandVerifier VerifyTargetOrPixel: target ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what to point ' , myName , ' at because ', msg.
				^ nil ].
		self pointAtRightNow: target undoable: true.
		^ self. ].

	(aDuration = eachFrame) ifTrue: [
		"Check the target to make sure it's valid"
		[ WonderlandVerifier VerifyTargetOrPixel: target ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what to point ' , myName , ' at because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self pointAtRightNow: target undoable: false ].
									].

	^ (self pointAt: target duration: aDuration style: gently).
