doEachFrame: aBlock
	"Build an action that causes the object to execute the block every frame"

	| newAction |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyZeroArgumentBlock: aBlock ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not make ' , myName , ' do what you asked because ', msg.
			^ nil ].

	newAction _ Action do: aBlock toObject: self inScheduler: (myWonderland getScheduler).
	(myWonderland getUndoStack) push:
			(UndoByStopping new: newAction in: (myWonderland getUndoStack)).

	^ newAction.