setColor: newColor duration: time
	"Set the scene's background color"

	(time = rightNow) ifTrue: [
		[ WonderlandVerifier VerifyColor: newColor ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what color to make the scene because ', msg.
				^ nil ].
	
		^ self setColorRightNow: newColor undoable: true ].

	^ (self setColor: newColor duration:time style: gently)

