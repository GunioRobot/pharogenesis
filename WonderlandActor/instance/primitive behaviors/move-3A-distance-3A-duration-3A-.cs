move: aDirection distance: aDistance duration: aDuration
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

		self moveRightNow: aDirection distance: aDistance undoable: true.
		^ self. ].

	^ (self move: aDirection distance: aDistance duration: aDuration style: gently).

