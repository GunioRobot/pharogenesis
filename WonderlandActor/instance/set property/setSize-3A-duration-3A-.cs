setSize: aVector duration: time
	"Sets the object's position and orientation"

	(time = rightNow) ifTrue: [
		[ WonderlandVerifier VerifyTriple: aVector ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what size to make ' , myName , ' because ', msg.
				^ nil ].

		self setSizeRightNow: aVector undoable: true.
		^ self. ].

	^ (self setSize: aVector duration:time style: gently).

