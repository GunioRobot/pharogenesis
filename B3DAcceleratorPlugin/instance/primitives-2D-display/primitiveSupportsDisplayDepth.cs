primitiveSupportsDisplayDepth
	| result depth |
	self export: true.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	depth _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	result _ self b3dxSupportsDisplayDepth: depth.
	interpreterProxy pop: 1.
	interpreterProxy pushBool: result.