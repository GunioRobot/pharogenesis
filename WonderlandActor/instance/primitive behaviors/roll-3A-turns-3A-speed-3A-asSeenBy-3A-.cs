roll: aDirection turns: numTurns speed: aSpeed asSeenBy: reference
	"Roll the actor the specified number of turns in the specified direction, taking the specified duration and using the specified animation style."

	| anim aDuration updateFunc degrees lastAmount buildMatrix newMatrix tMatrix|

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to roll ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: numTurns ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the number of turns to roll ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to roll ' , myName , ' at because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can not roll ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	anim _ RelativeAnimation new.
	aDuration _ (numTurns / aSpeed) abs.
	degrees _ 360 * numTurns.
	lastAmount _ 0.
	tMatrix _ B3DMatrix4x4 new.

	buildMatrix _ [ :rotMatrix | newMatrix _ reference getMatrixToRoot.
						newMatrix _ newMatrix composeWith: (self getMatrixFromRoot).
						newMatrix _ (((myParent getMatrixToRoot)
										composeWith: (reference getMatrixFromRoot))
										composeWith: rotMatrix)
										composeWith: newMatrix. ].

	(aDirection = #left) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. composite _ buildMatrix value: 
										(tMatrix rotationAroundZ: (tAngle - lastAmount)).
							lastAmount _ tAngle]]

		ifFalse: [(aDirection = #right) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. composite _ buildMatrix value: 
										(tMatrix rotationAroundZ: (tAngle - lastAmount)).
							lastAmount _ tAngle].
			degrees _ degrees negated. ]

		ifFalse: [ myWonderland reportErrorToUser: 'Squeak does not know how to roll ' , myName , ' ', (aDirection asString) , '.'.
				^ nil ]].
	
	anim object: self
			update: updateFunc
			getStartState: [ lastAmount _ 0. (Interpolateable value: 0) ]
			getEndState: [ degrees ]
			getReverseState: [ degrees negated ]
			style: abruptly
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
