primGetNextEvent: array
	"Store the next OS event available into the provided array.
	Essential. If the VM is not event driven the ST code will fall
	back to the old-style mechanism and use the state based
	primitives instead."
	| kbd buttons modifiers pos mapped |
	<primitive: 94>
	"Simulate the events"
	array at: 1 put: EventTypeNone. "assume no more events"

	"First check for keyboard"
	kbd _ super primKbdNext.
	kbd = nil ifFalse:[
		"simulate keyboard event"
		array at: 1 put: EventTypeKeyboard. "evt type"
		array at: 2 put: Time millisecondClockValue. "time stamp"
		array at: 3 put: (kbd bitAnd: 255). "char code"
		array at: 4 put: EventKeyChar. "key press/release"
		array at: 5 put: (kbd bitShift: -8). "modifier keys"
		^self].

	"Then check for mouse"
	buttons _ super primMouseButtons.
	pos _ super primMousePt.
	modifiers _ buttons bitShift: -3.
	buttons _ buttons bitAnd: 7.
	mapped _ self mapButtons: buttons modifiers: modifiers.
	(pos = mousePosition and:[(mapped bitOr: (modifiers bitShift: 3)) = mouseButtons])
		ifTrue:[^self].
	array 
		at: 1 put: EventTypeMouse;
		at: 2 put: Time millisecondClockValue;
		at: 3 put: pos x;
		at: 4 put: pos y;
		at: 5 put: mapped;
		at: 6 put: modifiers.
