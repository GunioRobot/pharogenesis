primitiveSetVerboseLevel
	| result level |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	level _ interpreterProxy stackIntegerValue: 0.
	result _ self cCode:'b3dxSetVerboseLevel(level)'.
	interpreterProxy pop: 2. "args+rcvr"
	^interpreterProxy pushInteger: result