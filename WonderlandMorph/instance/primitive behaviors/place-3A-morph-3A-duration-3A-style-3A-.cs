place: aLocation morph: aMorph duration: aDuration style: aStyle
	"Place this WonderlandMorph in the specified location relative to the specified morph."

	| anim endStateFunc |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyLocation: aLocation ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to place the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for placing the morph because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to place the morph because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	(aLocation = toLeftOf)
		ifTrue: [ endStateFunc _ [ ((aMorph left) - (self width)) @
										((aMorph center y) - ((self height) // 2)) ] ]
		ifFalse: [

	(aLocation = toRightOf)
		ifTrue: [ endStateFunc _ [ (aMorph right) @
										((aMorph center y) - ((self height) // 2)) ] ]
		ifFalse: [

	((aLocation = onTopOf) or: [ aLocation = above ])
		ifTrue: [ endStateFunc _ [ ((aMorph center x) - ((self width) // 2)) @
										((aMorph top) - (self height)) ] ]
		ifFalse: [

	(((aLocation = below) or: [ aLocation = beneath ]) or: [ aLocation = onBottomOf ])
		ifTrue: [ endStateFunc _ [ ((aMorph center x) - ((self width) // 2)) @
										(aMorph bottom) ] ]
		ifFalse: [

	(aLocation = onCeilingOf)
		ifTrue: [ endStateFunc _ [ ((aMorph center x) - ((self width) // 2)) @
										(aMorph top) ] ]
		ifFalse: [

	(aLocation = onFloorOf)
		ifTrue: [ endStateFunc _ [ ((aMorph center x) - ((self width) // 2)) @
										((aMorph bottom) - (self height)) ] ]
		ifFalse: [

	(aLocation = inFrontOf)
		ifTrue: [ endStateFunc _ [ self sendInFrontOf: aMorph.
								   self position ] ]
		ifFalse: [

	((aLocation = inBackOf) or: [ aLocation = behind ])
		ifTrue: [ endStateFunc _ [ self sendBehind: aMorph.
								   self position ] ]

				]]]]]]].

	anim object: self
			update: [:tPos | self position: (tPos rounded)]
			getStartState: [self position]
			getEndState: endStateFunc
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
