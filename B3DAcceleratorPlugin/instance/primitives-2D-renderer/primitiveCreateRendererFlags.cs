primitiveCreateRendererFlags
	| flags h w y x result  |
	self export: true.
	interpreterProxy methodArgumentCount = 5
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	y _ interpreterProxy stackIntegerValue: 2.
	x _ interpreterProxy stackIntegerValue: 3.
	flags _ interpreterProxy stackIntegerValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxCreateRendererFlags(x, y, w, h, flags)'.
	result < 0 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 6.
	^interpreterProxy pushInteger: result.