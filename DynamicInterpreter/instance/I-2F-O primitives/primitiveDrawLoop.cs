primitiveDrawLoop
	"Invoke the line drawing primitive."
	| rcvr xDelta yDelta |
	rcvr _ self stackValue: 2.
	xDelta _ self stackIntegerValue: 1.
	yDelta _ self stackIntegerValue: 0.
	self success: (self loadBitBltFrom: rcvr).
	successFlag ifTrue: [
		self drawLoopX: xDelta Y: yDelta.
		self showDisplayBits.
		self pop: 2].