primitiveSetViewport
	| h w y x result handle |
	self export: true.
	interpreterProxy methodArgumentCount = 5
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	y _ interpreterProxy stackIntegerValue: 2.
	x _ interpreterProxy stackIntegerValue: 3.
	handle _ interpreterProxy stackIntegerValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxSetViewport(handle, x, y, w, h)'.
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 5. "pop args; return rcvr"