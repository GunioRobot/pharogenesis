roll: aDirection turns: numTurns speed: aSpeed
	"Roll the actor the specified number of turns in the specified direction, taking the specified duration and using the specified animation style."

	| anim aDuration updateFunc degrees lastAmount tMatrix |

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

	aDuration _ (numTurns / aSpeed) abs.
	anim _ RelativeAnimation new.
	degrees _ 360 * numTurns.
	lastAmount _ 0.
	tMatrix _ B3DMatrix4x4 new.

	(aDirection = #left) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundZ: (tAngle - lastAmount)).
							lastAmount _ tAngle]]

		ifFalse: [(aDirection = #right) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
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
