actorState
	"This method instantiates actorState as a side-effect.
	For simple queries, use actorStateOrNil"
	| state |
	state _ self actorStateOrNil.
	state ifNil:
		[state _ ActorState new initializeFor: self assuredPlayer.
		self actorState: state].
	^ state