turnTo: aVector duration: aDuration
	"Turns the object to the specified orientation in its parent's coordinate system over the specified duration using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to turn ' , myName , ' to because ', msg.
				^ nil ].

		self turnToRightNow: aVector undoable: true.
		^ self. ].

	(aDuration = eachFrame) ifTrue: [
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to turn ' , myName , ' to because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self turnToRightNow: aVector	undoable: false ].
									].

	^ (self turnTo: aVector duration: aDuration style: gently).
