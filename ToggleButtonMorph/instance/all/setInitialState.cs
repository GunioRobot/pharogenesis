setInitialState
	state _ (target perform: stateSelector) == true
		ifTrue:
			[#on]
		ifFalse:
			[#off]