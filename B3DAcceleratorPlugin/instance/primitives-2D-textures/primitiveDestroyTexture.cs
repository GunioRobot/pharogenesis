primitiveDestroyTexture
	| handle result renderer |
	self export: true.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	handle _ interpreterProxy stackIntegerValue: 0.
	renderer _ interpreterProxy stackIntegerValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxDestroyTexture(renderer, handle)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 2. "pop arg; return rcvr"