primitiveCreateRenderer
	"NOTE: This primitive is obsolete but should be supported for older images"
	| h w y x result allowHardware allowSoftware |
	self export: true.
	interpreterProxy methodArgumentCount = 6
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	y _ interpreterProxy stackIntegerValue: 2.
	x _ interpreterProxy stackIntegerValue: 3.
	allowHardware _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 4).
	allowSoftware _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 5).
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxCreateRenderer(allowSoftware, allowHardware, x, y, w, h)'.
	result < 0 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 7.
	^interpreterProxy pushInteger: result.