move: aDirection distance: aDistance duration: aDuration style: aStyle
	"Move the actor the specified distance in the specified direction, taking the specified duration and using the specified animation style."

	| anim aPoint tmpPoint |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyDirection: aDirection ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the direction to move the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNumber: aDistance ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the distance to move the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for moving the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to move the morph because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ RelativeAnimation new.
	tmpPoint _ 0@0.

	(aDirection = left) ifTrue: [ aPoint _ (aDistance negated)@0 ]
		ifFalse: [ (aDirection = right) ifTrue: [ aPoint _ aDistance@0 ]
					ifFalse: [ (aDirection = up) ifTrue: [ aPoint _ 0@(aDistance negated) ]
								ifFalse: [ (aDirection = down) ifTrue: [ aPoint _ 0@aDistance ]
										ifFalse: [ myWonderland reportErrorToUser: 'Squeak does not know how to move the morph in that direction.'.
												^ nil ].
										].
							].
				].

	anim object: self
			update: [:tPos | self position: ((self position) + ((tPos rounded) - tmpPoint)).
							tmpPoint _ tPos rounded]
			getStartState: [tmpPoint _ 0@0. Interpolateable value: 0@0. ]
			getEndState: [ aPoint ]
			getReverseState: [ aPoint negated ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
