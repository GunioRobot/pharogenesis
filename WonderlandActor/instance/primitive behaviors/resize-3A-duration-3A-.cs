resize: amount duration: aDuration
	"Resize the object by the specified amount over the specified duration using the Gently animation style."

	(aDuration = rightNow) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyNumberOrTriple: amount ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , '  because ', msg.
				^ nil ].

		(amount isNumber)
			ifTrue: [ self resizeRightNow: (B3DVector3 x: amount y: amount z: amount)
							undoable: true. ]
			ifFalse: [ self resizeRightNow: (B3DVector3 x: (amount at: 1) y: (amount at: 2)
							z: (amount at: 3)) undoable: true. ].
		^ self.
									].

	(aDuration = eachFrame) ifTrue: [
		"Check our arguments to make sure they're valid"
		[ WonderlandVerifier VerifyNumberOrTriple: amount ]
			ifError: [ :msg :rcvr |
				myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , '  because ', msg.
				^ nil ].

		myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).

		(amount isNumber)
			ifTrue: [ ^ self doEachFrame: [ self resizeRightNow: (B3DVector3 x: amount y:
												amount z: amount) undoable: false ] ]
			ifFalse: [ ^ self doEachFrame: [ self resizeRightNow: (B3DVector3 x: (amount at: 1)
												y: (amount at: 2) z: (amount at: 3))
												undoable: true. ] ].
									].

	(amount isNumber)
		ifTrue: [ ^ (self resizeTopToBottom: amount leftToRight: amount frontToBack: amount
						duration: 1.0
						style: gently). ]
		ifFalse: [  ^ (self resizeTopToBottom: (amount at: 2)
						leftToRight: (amount at: 1)
						frontToBack: (amount at: 3)
						duration: 1.0
						style: gently). ].
