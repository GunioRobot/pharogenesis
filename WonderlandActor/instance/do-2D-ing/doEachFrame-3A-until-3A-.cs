doEachFrame: aBlock until: aCondition
	"Build an action that causes the object to execute the block every frame until the specified condition is true"

	| newAction |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyZeroArgumentBlock: aBlock ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not make ' , myName , ' do what you asked because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyCondition: aCondition ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine for how long ' , myName , ' should do this because ', msg.
			^ nil ].

	newAction _ Action do: aBlock eachframeuntil: aCondition toObject: self
						inScheduler: (myWonderland getScheduler).
	(myWonderland getUndoStack) push:
			(UndoByStopping new: newAction in: (myWonderland getUndoStack)).

	^ newAction.