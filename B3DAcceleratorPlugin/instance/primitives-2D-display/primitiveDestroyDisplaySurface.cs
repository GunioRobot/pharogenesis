primitiveDestroyDisplaySurface
	| handle result |
	self export: true.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	handle _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxDestroyDisplaySurface(handle)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 1. "pop arg; return rcvr"