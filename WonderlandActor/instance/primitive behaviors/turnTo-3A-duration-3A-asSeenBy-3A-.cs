turnTo: aVector duration: aDuration asSeenBy: reference
	"Turns the object to the specified orientation in its parent's coordinate system over the specified duration using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to turn ' , myName , ' to because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not turn ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

		self turnToRightNow: aVector asSeenBy: reference undoable: true.
		^ self. ].

	(aDuration = eachFrame) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyTarget: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine where to turn ' , myName , ' to because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not turn ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoPOVChange for: self from: (self getPointOfView)).

		^ self doEachFrame: [ self turnToRightNow: aVector asSeenBy: reference undoable: false ].
									].

	^ (self turnTo: aVector duration: aDuration asSeenBy: reference style: gently).
