primitiveSetDisplayMode
	"Set to OS to the requested display mode.
	See also DisplayScreen setDisplayDepth:extent:fullscreen:"
	| fsFlag h w d okay |
	fsFlag _ self booleanValueOf: (self stackTop).
	h _ self stackIntegerValue: 1.
	w _ self stackIntegerValue: 2.
	d _ self stackIntegerValue: 3.
	successFlag ifTrue: [okay _ self cCode:'ioSetDisplayMode(w, h, d, fsFlag)'].
	successFlag ifTrue: [
		self pop: 5. "Pop args+rcvr"
		self pushBool: okay].