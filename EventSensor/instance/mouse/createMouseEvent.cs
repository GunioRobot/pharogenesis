createMouseEvent
	"create and return a new mouse event from the current mouse 
	position; this is useful for restarting normal event queue 
	processing after manual polling"

	| buttons modifiers pos mapped eventBuffer |
	eventBuffer _ Array new: 8.
	buttons _ self primMouseButtons.
	pos _ self primMousePt.
	modifiers _ buttons bitShift: -3.
	buttons _ buttons bitAnd: 7.
	mapped _ self mapButtons: buttons modifiers: modifiers.
	eventBuffer
		at: 1
		put: EventTypeMouse;
		 at: 2 put: Time millisecondClockValue;
		 at: 3 put: pos x;
		 at: 4 put: pos y;
		 at: 5 put: mapped;
		 at: 6 put: modifiers.
	^ eventBuffer