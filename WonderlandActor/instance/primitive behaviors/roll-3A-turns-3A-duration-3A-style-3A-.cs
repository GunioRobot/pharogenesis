roll: aDirection turns: numTurns duration: aDuration style: aStyle
	"Roll the actor the specified number of turns in the specified direction, taking the specified duration and using the specified animation style."

	| anim updateFunc degrees lastAmount tMatrix|

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to roll ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: numTurns ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the number of turns to roll ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for rolling ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to roll ' , myName , ' because ', msg.
			^ nil ].

	"The parameters check out, so go ahead and build the animation"
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
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
