setColor: newColor duration: time
	"Set the actor's color"

	(time = rightNow) ifTrue: [
		[ WonderlandVerifier VerifyColor: newColor ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what color to make ' , myName , ' because ', msg.
				^ nil ].

		self setColorRightNow: newColor undoable: true.
		^ self. ].

	^ (self setColor: newColor duration:time style: gently)

