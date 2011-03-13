stopButtonState: newState
	stopButton ifNotNil:
		[newState
			ifTrue: [stopButton state: #on]
			ifFalse: [stopButton state: #off]]