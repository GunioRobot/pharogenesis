setVisibility: newVisibility duration: time
	"Sets the current object's visibility"

	(time = rightNow) ifTrue: [
		[ WonderlandVerifier Verify0To1Number: newVisibility ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine what visibility to make ' , myName , ' because ', msg.
				^ nil ].

		self setVisibilityRightNow: newVisibility undoable: true.
		^ self. ].

	^ (self setVisibility: newVisibility duration: time
			style: gently).

