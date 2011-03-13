buttonDownToToggleState
	| targetState |
	self doButtonAction.
	targetState _ (target perform: stateSelector) ifTrue: [#on] ifFalse: [#off].
	targetState = state ifFalse: [self toggleState]