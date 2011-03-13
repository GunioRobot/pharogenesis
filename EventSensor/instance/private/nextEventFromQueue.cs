nextEventFromQueue
	"Return the next event from the receiver."
	self eventQueue isEmpty ifTrue:[self fetchMoreEvents].
	self eventQueue isEmpty
		ifTrue:[^nil]
		ifFalse:[^self eventQueue next]