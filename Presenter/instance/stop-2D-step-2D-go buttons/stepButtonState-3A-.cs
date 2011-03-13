stepButtonState: newState
	stepButton ifNotNil:
		[newState
			ifTrue: [stepButton state: #on]
			ifFalse: [stepButton state: #off]]