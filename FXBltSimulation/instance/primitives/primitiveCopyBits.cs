primitiveCopyBits
	| rcvr |
	self export: true.
	self inline: false.
	rcvr _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	(self loadBitBltFrom: rcvr) ifFalse:[^interpreterProxy primitiveFail].
	self copyBits.
	self showDisplayBits.