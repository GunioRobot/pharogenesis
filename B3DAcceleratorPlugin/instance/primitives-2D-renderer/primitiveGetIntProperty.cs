primitiveGetIntProperty
	| handle prop result |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	prop _ interpreterProxy stackIntegerValue: 0.
	handle _ interpreterProxy stackIntegerValue: 1.
	result _ self cCode:'b3dxGetIntProperty(handle, prop)'.
	interpreterProxy pop: 3. "args+rcvr"
	^interpreterProxy pushInteger: result