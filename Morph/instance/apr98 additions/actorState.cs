actorState
	| state |
	state _ self valueOfProperty: #actorState.
	state ifNil:
		[self setProperty: #actorState toValue: (state _ ActorState new initializeFor: self assuredCostumee)].
	^ state