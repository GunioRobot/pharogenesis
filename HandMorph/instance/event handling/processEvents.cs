processEvents
	"Process user input events from the local input devices.
	An interesting problem. Morphic is always supposed to run in an event driven environment but for now it is possible that a Morphic window is run from MVC so that we have to synthesize events in the sensor. That's quite a bit of a problem because it means that we'll get endless mouse events. To compensate for this, EventSensor will always return keyboard events first if synthesized so if we're running into a mouse event AND Sensor doesn't have an event queue we can safely break out of the event processing loop. See also EventSensor>>nextEventSynthesized."
	| evt evtBuf type hadMouse hadAny |
	hadMouse _ hadAny _ false.
	[(evtBuf _ Sensor nextEvent) == nil] whileFalse:[
		evt _ nil. "for unknown event types"
		type _ evtBuf at: 1.
		(type = EventTypeMouse)
			ifTrue:[evt _ self generateMouseEvent: evtBuf. hadMouse _ true].
		(type = EventTypeKeyboard) 
			ifTrue:[evt _ self generateKeyboardEvent: evtBuf].
		(type = EventTypeDragDropFiles)
			ifTrue:[evt _ self generateDropFilesEvent: evtBuf].
		"All other events are ignored"

		evt == nil ifFalse:[
			"Finally, handle it"
			self handleEvent: evt.
			hadAny _ true.

			"See the note on running a World in MVC in the method comment"
			(evt isMouse and:[Sensor eventQueue == nil]) ifTrue:[^self].
		].
	].
	(mouseClickState notNil and:[hadMouse not]) ifTrue:[
		"No mouse events during this cycle. Make sure click states time out accordingly"
		mouseClickState handleEvent: lastMouseEvent asMouseMove from: self].
	hadAny ifFalse:[
		"No pending events. Make sure z-order is up to date"
		self mouseOverHandler processMouseOver: lastMouseEvent.
	].