primitiveFillDisplaySurface
	| h w result y x pv handle |
	self export: true.
	interpreterProxy methodArgumentCount = 6
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	y _ interpreterProxy stackIntegerValue: 2.
	x _ interpreterProxy stackIntegerValue: 3.
	pv _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 4).
	handle _ interpreterProxy stackIntegerValue: 5.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxFillDisplaySurface(handle, pv, x, y, w, h)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 6. "pop args; return rcvr"