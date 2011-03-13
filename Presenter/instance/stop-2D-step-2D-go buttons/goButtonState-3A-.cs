goButtonState: newState
	goButton ifNotNil:
		[newState
			ifTrue: [goButton state: #on]
			ifFalse: [goButton state: #off]]