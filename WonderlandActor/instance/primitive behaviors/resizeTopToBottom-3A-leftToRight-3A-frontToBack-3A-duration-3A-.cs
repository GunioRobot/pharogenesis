resizeTopToBottom: height leftToRight: width frontToBack: thickness duration: aDuration
	"Resize the object by the specified amount over the specified duration using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyNumber: height ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from top to bottom because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: width ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from left to right because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: thickness ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from front to back because ', msg.
				^ nil ].

		self resizeRightNow: (B3DVector3 x: width y: height z: thickness) undoable: true.
		^ self.
									].

	(aDuration = eachFrame) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyNumber: height ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from top to bottom because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: width ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from left to right because ', msg.
				^ nil ].

		[ WonderlandVerifier VerifyNumber: thickness ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , ' from front to back because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).

		^ self doEachFrame: [ self resizeRightNow: (B3DVector3 x: width y: height z: thickness)
									undoable: false ]
									].

	^ (self resizeTopToBottom: height leftToRight: width frontToBack: thickness
				duration: aDuration style: gently).

