primitiveDrawLoop
	"Invoke the line drawing primitive."
	| rcvr xDelta yDelta |
	self export: true.
	rcvr _ interpreterProxy stackValue: 2.
	xDelta _ interpreterProxy stackIntegerValue: 1.
	yDelta _ interpreterProxy stackIntegerValue: 0.
	(self loadBitBltFrom: rcvr) ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy failed ifFalse:[
		self drawLoopX: xDelta Y: yDelta.
		self showDisplayBits].
	interpreterProxy failed ifFalse:[interpreterProxy pop: 2].