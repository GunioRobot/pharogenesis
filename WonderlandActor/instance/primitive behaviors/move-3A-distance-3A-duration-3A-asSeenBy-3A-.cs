move: aDirection distance: aDistance duration: aDuration asSeenBy: reference
	"Move the actor the specified distance in the specified direction, taking the specified duration and using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyDirection: aDirection ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the direction to move ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: aDistance ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine the distance to move ' , myName , ' because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyReferenceFrame: reference ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak can not move ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
				^ nil ].

		self moveRightNow: aDirection distance: aDistance asSeenBy: reference undoable: true.
		^ self. ].

	^ (self move: aDirection distance: aDistance duration: aDuration asSeenBy: reference
			style: gently).

