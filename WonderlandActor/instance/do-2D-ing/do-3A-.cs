do: aBlock
	"Build an animation that causes the object to execute the block"

	| anim |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyZeroArgumentBlock: aBlock ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not make ' , myName , ' do what you asked because ', msg.
			^ nil ].

	anim _ RelativeAnimation new.

	anim object: self
		update: [:tmp | aBlock value ]
		getStartState: [ Interpolateable value: 0 ]
		getEndState: [ 1 ]
		getReverseState: [ 1 ]
		style: abruptly
		duration: 0
		undoable: false
		inWonderland: myWonderland.

	^ anim.