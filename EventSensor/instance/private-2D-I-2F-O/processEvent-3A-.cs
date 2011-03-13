processEvent: evt 
	"Process a single event. This method is run at high priority."
	| type window |
	type := evt at: 1.
	
	
	window := evt at: 8.
	(window isNil or: [window isZero]) ifTrue: 
		[window := 1. 
		evt at: 8 put: window].	
	window := evt at: 8.
	(window isNil or: [window isZero]) ifTrue: 
		[window := 1. 
		evt at: 8 put: window].
	
	
		"Tackle mouse events first"
	type = EventTypeMouse
		ifTrue: [evt
				at: 5
				put: (ButtonDecodeTable at: (evt at: 5)
							+ 1). 
				self queueEvent: evt.
				self processMouseEvent: evt . 
				^self].
	
	
	"Store the event in the queue if there's any"
	type = EventTypeKeyboard
		ifTrue: [ "Check if the event is a user interrupt"
			((evt at: 4) = 0
				and: [((evt at: 3)
						bitOr: (((evt at: 5)
							bitAnd: 8)
							bitShift: 8))
							= interruptKey])
					ifTrue: ["interrupt key is meta - not reported as event"
							^ interruptSemaphore signal].
			"Else swap ctrl/alt keys if neeeded.wi"
			KeyDecodeTable
				at: {evt at: 3. evt at: 5}
				ifPresent: [:a | evt at: 3 put: a first;
						 at: 5 put: a second]. 
			self queueEvent: evt. 
			self processKeyboardEvent: evt . 
			^self ].
				
				
      EventTypeWindow = type ifTrue: 
		[self processWindowEvent: evt. 
		^self].
	     
	EventTypeMenu = type ifTrue: 
		[self processMenuEvent: evt. 
		^self].

	"Handle all events other than Keyborad or Mouse."
	self queueEvent: evt.
	