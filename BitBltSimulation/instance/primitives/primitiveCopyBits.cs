primitiveCopyBits
	"Invoke the copyBits primitive. If the destination is the display, then copy it to the screen."
	| rcvr |
	self export: true.
	rcvr _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	(self loadBitBltFrom: rcvr) 
		ifFalse:[^interpreterProxy primitiveFail].
	self copyBits.
	self showDisplayBits.