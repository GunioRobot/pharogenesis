primitiveWarpBits
	"Invoke the warpBits primitive. If the destination is the display, then copy it to the screen."
	| rcvr |
	rcvr _ self stackValue: self argCount.
	self success: (self loadBitBltFrom: rcvr).
	successFlag ifTrue: [
		self warpBits.
		self showDisplayBits.
	].