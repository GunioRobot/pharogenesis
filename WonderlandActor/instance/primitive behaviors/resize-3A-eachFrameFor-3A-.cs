resize: amount eachFrameFor: aLifetime
	"Resize the object by the specified amount each frame for the specified lifetime."

	| aVector |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyNumberOrTriple: amount ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how much to resize ' , myName , '  because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNonNegativeNumber: aLifetime ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how long it should resize ' , myName , ' because ', msg.
			^ nil ].

	myWonderland getUndoStack push: (UndoSizeChange for: self from: (self getSize)).

	(amount isNumber)
		ifTrue: [ aVector _ (B3DVector3 x: amount y: amount z: amount) ]
		ifFalse: [ aVector _ (B3DVector3 x: (amount at: 1) y: (amount at: 2)
									 z: (amount at: 3)) ].

	^ self doEachFrame: [ self resizeRightNow: aVector undoable: false ]
			for: aLifetime.


