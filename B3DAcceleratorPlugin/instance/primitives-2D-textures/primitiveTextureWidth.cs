primitiveTextureWidth
	| handle result |
	self export: true.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	handle _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxActualTextureWidth(handle)' inSmalltalk:[-1].
	result < 0 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 2.
	interpreterProxy pushInteger: result.