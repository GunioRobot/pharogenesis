primitiveIsOverlayRenderer
	| handle result |
	self export: true.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	handle _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxIsOverlayRenderer(handle)' inSmalltalk:[false].
	interpreterProxy pop: 2. "args+rcvr"
	^interpreterProxy pushBool: result.