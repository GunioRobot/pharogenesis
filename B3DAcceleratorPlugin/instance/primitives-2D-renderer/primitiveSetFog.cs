primitiveSetFog
	| result handle rgba density fogType stop start |
	self export: true.
	self var: #density type:'double'.
	self var: #start type: 'double'.
	self var: #stop type: 'double'.
	interpreterProxy methodArgumentCount = 6
		ifFalse:[^interpreterProxy primitiveFail].
	rgba _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	stop _ interpreterProxy floatValueOf: (interpreterProxy stackValue: 1).
	start _ interpreterProxy floatValueOf: (interpreterProxy stackValue: 2).
	density _ interpreterProxy floatValueOf: (interpreterProxy stackValue: 3).
	fogType _ interpreterProxy stackIntegerValue: 4.
	handle _ interpreterProxy stackIntegerValue: 5.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxSetFog(handle, fogType, density, start, stop, rgba)'.
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 6. "pop args; return rcvr"