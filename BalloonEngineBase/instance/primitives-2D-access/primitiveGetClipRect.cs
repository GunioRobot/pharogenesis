primitiveGetClipRect
	| rectOop pointOop |
	self export: true.	
	self inline: false.

	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].

	rectOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].

	(interpreterProxy isPointers: rectOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: rectOop) < 2
		ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy pushRemappableOop: rectOop.
	pointOop _ interpreterProxy makePointwithxValue: self clipMinXGet yValue: self clipMinYGet.
	rectOop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: rectOop withValue: pointOop.
	interpreterProxy pushRemappableOop: rectOop.
	pointOop _ interpreterProxy makePointwithxValue: self clipMaxXGet yValue: self clipMaxYGet.
	rectOop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 1 ofObject: rectOop withValue: pointOop.

	interpreterProxy pop: 2.
	interpreterProxy push: rectOop.