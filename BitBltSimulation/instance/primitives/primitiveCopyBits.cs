primitiveCopyBits
	"Invoke the copyBits primitive. If the destination is the display, then copy it to the screen."
	| rcvr |
	self export: true.
	rcvr _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	(self loadBitBltFrom: rcvr)  ifFalse:[^interpreterProxy primitiveFail].
	self copyBits.
	interpreterProxy failed ifTrue:[^nil].
	self showDisplayBits.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: interpreterProxy methodArgumentCount.
	(combinationRule = 22) | (combinationRule = 32) ifTrue:[
		interpreterProxy pop: 1.
		^ interpreterProxy pushInteger: bitCount].