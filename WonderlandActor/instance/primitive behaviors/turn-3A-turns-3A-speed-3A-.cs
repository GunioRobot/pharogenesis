turn: aDirection turns: numTurns speed: aSpeed
	"Turn the actor the specified distance in the specified direction, taking the specified duration and using the specified animation style."

	| anim aDuration updateFunc degrees lastAmount tMatrix |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to turn ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: numTurns ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how many turns to turn ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyPositiveNumber: aSpeed ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the speed to turn ' , myName , ' at because ', msg.
			^ nil ].

	aDuration _ (numTurns / aSpeed) abs.

	anim _ RelativeAnimation new.
	degrees _ 360 * numTurns.
	lastAmount _ 0.
	tMatrix _ B3DMatrix4x4 new.

	(aDirection = #right) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundY: (tAngle - lastAmount)).
							lastAmount _ tAngle] ]

		ifFalse: [(aDirection = #left) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundY: (tAngle - lastAmount)).
							lastAmount _ tAngle].
			degrees _ degrees negated ]

		ifFalse: [(((aDirection = #up) or: [aDirection = #back]) or: [aDirection = #backward])
			ifTrue: [
				updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundX: (tAngle - lastAmount)).
							lastAmount _ tAngle].
				degrees _ degrees negated ]

		ifFalse: [((aDirection = #down) or: [aDirection = #forward]) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundX: (tAngle - lastAmount)).
							lastAmount _ tAngle]]

		ifFalse: [(aDirection = #ccw) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundZ: (tAngle - lastAmount)).
							lastAmount _ tAngle]]

		ifFalse: [(aDirection = #cw) ifTrue: [
			updateFunc _ [:tAngle | tMatrix setIdentity. self rotateByMatrix:
										(tMatrix rotationAroundZ: (tAngle - lastAmount)).
							lastAmount _ tAngle].
			degrees _ degrees negated. ]

		ifFalse: [ self error: 'Unrecognized direction' ]]]]]].
	
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
