primitiveSetIntProperty
	| handle prop result value |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].
	value _ interpreterProxy stackIntegerValue: 0.
	prop _ interpreterProxy stackIntegerValue: 1.
	handle _ interpreterProxy stackIntegerValue: 2.
	result _ self cCode:'b3dxSetIntProperty(handle, prop, value)'.
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 3. "args; return rcvr"
