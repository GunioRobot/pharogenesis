moveTo: aVector duration: aDuration style: aStyle
	"Moves the object to the specified position in its parent's coordinate system using the specified style over the specified duration."

	| anim pos endStateFunc |

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

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to move ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	(aVector isKindOf: WonderlandActor)
		ifTrue: [ endStateFunc _ [ pos _ aVector getPosition: myParent.
				 				   B3DVector3 x: (pos at: 1) y: (pos at: 2) z: (pos at: 3). ]
				]
		ifFalse: [ endStateFunc _ [
						pos _ self getPositionVector.
				  		((aVector at: 1) = asIs) ifFalse: [pos x: (aVector at: 1) ].
				  		((aVector at: 2) = asIs) ifFalse: [pos y: (aVector at: 2) ].
				  		((aVector at: 3) = asIs) ifFalse: [pos z: (aVector at: 3) ].
				  		pos.
								]
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
