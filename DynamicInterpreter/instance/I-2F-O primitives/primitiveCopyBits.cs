primitiveCopyBits
	"Invoke the copyBits primitive. If the destination is the display, then copy it to the screen."

	| rcvr |
	rcvr _ self stackTop.
	self success: (self loadBitBltFrom: rcvr).
	successFlag ifTrue: [
		self copyBits.
		self showDisplayBits.
	].