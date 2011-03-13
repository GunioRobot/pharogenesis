nextEventFromQueue
	"Return the next event from the receiver."

	EventPollFrequency _ 20.	"since Squeak is taking the event, reset to normal delay"
	eventQueue isEmpty
		ifTrue:[^nil]
		ifFalse:[^eventQueue next]