nextEventFromQueue
	"Return the next event from the receiver."
	eventQueue isEmpty ifTrue:[self fetchMoreEvents].
	eventQueue isEmpty
		ifTrue:[^nil]
		ifFalse:[^eventQueue next]