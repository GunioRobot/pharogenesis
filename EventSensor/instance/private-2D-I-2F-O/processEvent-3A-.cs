processEvent: evt
	"Process a single event. This method is run at high priority."
	| type |
	type _ evt at: 1.

	"Check if the event is a user interrupt"
	(type = EventTypeKeyboard and:[(evt at: 4) = 0 and:[
		((evt at: 3) bitOr: ((evt at: 5) bitShift: 8)) = interruptKey]])
			 ifTrue:["interrupt key is meta - not reported as event"
					^interruptSemaphore signal].

	"Store the event in the queue if there's any"
	type = EventTypeMouse ifTrue:
		[evt at: 5 put: (ButtonDecodeTable at: (evt at: 5) + 1)].

	type = EventTypeKeyboard ifTrue:
		["swap ctrl/alt keys"
		KeyDecodeTable at: { evt at: 3 . evt at: 5 } ifPresent: [:a |
			evt at: 3 put: a first;
				at: 5 put: a second]].

	self queueEvent: evt.

	"Update state for InputSensor."
	EventTypeMouse = type ifTrue:[self processMouseEvent: evt].
	EventTypeKeyboard = type ifTrue:[self processKeyboardEvent: evt]