primitiveTextureUpload
	| h w d result form bits ppw bitsPtr handle renderer |
	self export: true.
	self var: #bitsPtr type: 'void*'.
	interpreterProxy methodArgumentCount = 3
		ifFalse:[^interpreterProxy primitiveFail].
	form _ interpreterProxy stackValue: 0.
	((interpreterProxy isPointers: form) and:[(interpreterProxy slotSizeOf: form) >= 4])
		ifFalse:[^interpreterProxy primitiveFail].
	bits _ interpreterProxy fetchPointer: 0 ofObject: form.
	w _ interpreterProxy fetchInteger: 1 ofObject: form.
	h _ interpreterProxy fetchInteger: 2 ofObject: form.
	d _ interpreterProxy fetchInteger: 3 ofObject: form.
	ppw _ 32 // d.
	(interpreterProxy isWords: bits)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: bits) = (w + ppw - 1 // ppw * h)
		ifFalse:[^interpreterProxy primitiveFail].
	bitsPtr _ interpreterProxy firstIndexableField: bits.
	handle _ interpreterProxy stackIntegerValue: 1.
	renderer _ interpreterProxy stackIntegerValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxUploadTexture(renderer, handle, w, h, d, bitsPtr)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 3. "args; return rcvr"