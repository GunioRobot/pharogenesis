primitiveCompositeTexture
	| result translucent y x w h texHandle rendererHandle |
	self export: true.
	interpreterProxy methodArgumentCount = 7
		ifFalse:[^interpreterProxy primitiveFail].
	translucent _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	h _ interpreterProxy stackIntegerValue: 1.
	w _ interpreterProxy stackIntegerValue: 2.
	y _ interpreterProxy stackIntegerValue: 3.
	x _ interpreterProxy stackIntegerValue: 4.
	texHandle _ interpreterProxy stackIntegerValue: 5.
	rendererHandle _ interpreterProxy stackIntegerValue: 6.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxCompositeTexture(rendererHandle, texHandle, x, y, w, h, translucent)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 7. "args"
