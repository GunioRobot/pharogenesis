ioProcess
	"Run the i/o process"
	| eventBuffer type |
	eventBuffer _ Array new: 8.
	[true] whileTrue:[
		[self primGetNextEvent: eventBuffer.
		type _ eventBuffer at: 1.
		type = EventTypeNone] whileFalse:[self processEvent: eventBuffer].
		inputSemaphore waitTimeoutMSecs: EventPollFrequency.
		Preferences higherPerformance ifTrue: [
			EventPollFrequency _ (EventPollFrequency * 1.5) rounded min: 500.
		].
	].
