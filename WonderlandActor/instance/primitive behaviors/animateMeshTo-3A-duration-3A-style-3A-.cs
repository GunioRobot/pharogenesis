animateMeshTo: param duration: aDuration style: aStyle
	"Turns the object to point at the specified target using the specified style over the specified duration."
	| anim |
	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyNumber: param ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what to animate to because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use animating ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to animate ' , myName , ' because ', msg.
			^ nil ].

	"The parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	anim object: self
			update: [:t | self setMeshAnimationParameter: t ]
			getStartState: [self getMeshAnimationParameter]
			getEndState: [ param ]
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
