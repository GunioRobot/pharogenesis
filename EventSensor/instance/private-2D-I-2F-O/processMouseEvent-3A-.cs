processMouseEvent: evt
	"process a mouse event, updating InputSensor state"
	| modifiers buttons mapped |
	mousePosition _ (evt at: 3) @ (evt at: 4).
	buttons _ evt at: 5.
	modifiers _ evt at: 6.
	mapped _ self mapButtons: buttons modifiers: modifiers.
	mouseButtons _ mapped bitOr: (modifiers bitShift: 3).