primitiveWarpBits
	"Invoke the warpBits primitive. If the destination is the display, then copy it to the screen."
	| rcvr |
	self export: true.
	rcvr _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	(self loadWarpBltFrom: rcvr) 
		ifFalse:[^interpreterProxy primitiveFail].
	self warpBits.
	interpreterProxy failed ifTrue:[^nil].
	self showDisplayBits.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: interpreterProxy methodArgumentCount.