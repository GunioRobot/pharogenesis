nextEventSynthesized
	"Return a synthesized event. This method is called if an event driven client wants to receive events but the primary user interface is not event-driven (e.g., the receiver does not have an event queue but only updates its state). This can, for instance, happen if a Morphic World is run in an MVC window. To simplify the clients work this method will always return all available keyboard events first, and then (repeatedly) the mouse events. Since mouse events come last, the client can assume that after one mouse event has been received there are no more to come. Note that it is impossible for EventSensor to determine if a mouse event has been issued before so the client must be aware of the possible problem of getting repeatedly the same mouse events. See HandMorph>>processEvents for an example on how to deal with this."
	| kbd array buttons pos modifiers mapped |
	"First check for keyboard"
	array _ Array new: 8.
	kbd _ self primKbdNext.
	kbd ifNotNil:
		["simulate keyboard event"
		array at: 1 put: EventTypeKeyboard. "evt type"
		array at: 2 put: Time millisecondClockValue. "time stamp"
		array at: 3 put: (kbd bitAnd: 255). "char code"
		array at: 4 put: EventKeyChar. "key press/release"
		array at: 5 put: (kbd bitShift: -8). "modifier keys"
		^ array].

	"Then check for mouse"
	pos _ self primMousePt.
	buttons _ mouseButtons.
	modifiers _ buttons bitShift: -3.
	buttons _ buttons bitAnd: 7.
	mapped _ self mapButtons: buttons modifiers: modifiers.
	array 
		at: 1 put: EventTypeMouse;
		at: 2 put: Time millisecondClockValue;
		at: 3 put: pos x;
		at: 4 put: pos y;
		at: 5 put: mapped;
		at: 6 put: modifiers.
	^ array

