nextEvent
	"Return the next event from the receiver."
	eventQueue 
		ifNil:[^self nextEventSynthesized]
		ifNotNil:[^self nextEventFromQueue]
