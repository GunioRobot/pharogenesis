primitiveClearDepthBuffer
	| result |
	self export: true.
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	result _ self cCode:'b3dxClearDepthBuffer()'.
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 4. "pop args; return rcvr"