doEachFrame: aBlock for: aDuration
	"Build an action that causes the object to execute the block every frame for the specified amount of time"

	| newAction |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyZeroArgumentBlock: aBlock ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not make ' , myName , ' do what you asked because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNonNegativeNumber: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how long ' , myName , ' should do this because ', msg.
			^ nil ].

	newAction _ Action do: aBlock eachframefor: aDuration toObject: self
						inScheduler: (myWonderland getScheduler).
	(myWonderland getUndoStack) push:
			(UndoByStopping new: newAction in: (myWonderland getUndoStack)).

	^ newAction.
