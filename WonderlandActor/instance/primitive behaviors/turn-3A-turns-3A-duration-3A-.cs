turn: aDirection turns: numTurns duration: aDuration
	"Turn the actor the specified distance in the specified direction, taking the specified duration and using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyDirection: aDirection ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the direction to turn ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: numTurns ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how many turns to turn ' , myName , ' because ', msg.
				^ nil ].

		self turnRightNow: aDirection numberOfTurns: numTurns undoable: true.
		^ self. ].

	^ (self turn: aDirection turns: numTurns duration: aDuration style: gently).

