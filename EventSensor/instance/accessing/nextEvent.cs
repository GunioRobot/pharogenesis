nextEvent
	"Return the next event from the receiver."
	eventQueue == nil 
		ifTrue:[^self nextEventSynthesized]
		ifFalse:[^self nextEventFromQueue]
