moveTo: aVector duration: aDuration asSeenBy: reference style: aStyle
	"Moves the object to the specified position in its parent's coordinate system using the specified style over the specified duration."

	| anim endStateFunc pos newComposite vectorMatrix |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTarget: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to move ' , myName , ' to because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for moving ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can not move ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to move ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	endStateFunc _ [
		vectorMatrix _ B3DMatrix4x4 identity.
		pos _ self getPosition: reference.
		((aVector at: 1) = asIs) ifFalse: [ pos at: 1 put: (aVector at: 1) ].
		((aVector at: 2) = asIs) ifFalse: [ pos at: 2 put: (aVector at: 2) ].
		((aVector at: 3) = asIs) ifFalse: [ pos at: 3 put: (aVector at: 3) ].
		vectorMatrix translation: (B3DVector3 x: (pos at: 1) y: (pos at: 2) z: (pos at: 3)).
		newComposite _ (myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot).
		newComposite _ newComposite composeWith: vectorMatrix.
		newComposite translation.
					].


	anim object: self
			update: [:tPos | self setPositionVector: tPos]
			getStartState: [self getPositionVector]
			getEndState: endStateFunc
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
