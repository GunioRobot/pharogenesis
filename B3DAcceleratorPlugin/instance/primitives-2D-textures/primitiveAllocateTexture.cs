primitiveAllocateTexture
	| h w d result renderer |
	self export: true.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	d _ interpreterProxy stackIntegerValue: 2.
	renderer _ interpreterProxy stackIntegerValue: 3.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxAllocateTexture(renderer, w, h, d)' inSmalltalk:[-1].
	result = -1 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 5. "args+rcvr"
	^interpreterProxy pushInteger: result.