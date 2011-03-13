peekEvent
	"Look ahead at the next event."
	| nextEvent |
	nextEvent := eventQueue peek.
	^nextEvent
		ifNotNil: [self processEvent: nextEvent]