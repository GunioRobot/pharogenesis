roll: aDirection turns: numTurns duration: aDuration asSeenBy: reference
	"Roll the actor the specified number of turns in the specified direction, taking the specified duration and using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyDirection: aDirection ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the direction to roll ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: numTurns ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the number of turns to roll ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not roll ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

			self rollRightNow: aDirection numberOfTurns: numTurns
						asSeenBy: reference undoable: true.
			^ self. ].

	^ (self roll: aDirection turns: numTurns duration: aDuration asSeenBy: reference
			style: gently).

