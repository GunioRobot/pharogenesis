primitiveClearViewport
	| result handle pv rgba |
	self export: true.
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].
	pv _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	rgba _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 1).
	handle _ interpreterProxy stackIntegerValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxClearViewport(handle, rgba, pv)'.
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 3. "pop args; return rcvr"