primitiveSetViewport
	| h w y x result |
	self export: true.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	y _ interpreterProxy stackIntegerValue: 2.
	x _ interpreterProxy stackIntegerValue: 3.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxSetViewport(x, y, w, h)'.
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 4. "pop args; return rcvr"