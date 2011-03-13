nextEvent
	"Return the next event from the receiver."
	^eventQueue isEmpty
		ifTrue:[nil]
		ifFalse: [self processEvent: eventQueue next]