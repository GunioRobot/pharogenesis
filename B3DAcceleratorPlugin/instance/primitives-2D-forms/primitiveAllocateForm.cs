primitiveAllocateForm
	| h w d result |
	self export: true.
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].
	h _ interpreterProxy stackIntegerValue: 0.
	w _ interpreterProxy stackIntegerValue: 1.
	d _ interpreterProxy stackIntegerValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxAllocateForm(w, h, d)' inSmalltalk:[-1].
	result = -1 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 4. "args+rcvr"
	interpreterProxy pushInteger: result.