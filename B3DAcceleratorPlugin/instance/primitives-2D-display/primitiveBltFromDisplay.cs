primitiveBltFromDisplay
	| result extent srcOrigin dstOrigin extentX extentY sourceX sourceY destX destY formHandle displayHandle |
	self export: true.
	interpreterProxy methodArgumentCount = 5
		ifFalse:[^interpreterProxy primitiveFail].
	extent _ interpreterProxy stackObjectValue: 0.
	srcOrigin _ interpreterProxy stackObjectValue: 1.
	dstOrigin _ interpreterProxy stackObjectValue: 2.
	formHandle _ interpreterProxy stackIntegerValue: 3.
	displayHandle _ interpreterProxy stackIntegerValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isPointers: extent) and:[(interpreterProxy slotSizeOf: extent) = 2])
		ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: srcOrigin) and:[(interpreterProxy slotSizeOf: srcOrigin) = 2])
		ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isPointers: dstOrigin) and:[(interpreterProxy slotSizeOf: dstOrigin) = 2])
		ifFalse:[^interpreterProxy primitiveFail].
	extentX _ interpreterProxy fetchInteger: 0 ofObject: extent.
	extentY _ interpreterProxy fetchInteger: 1 ofObject: extent.
	sourceX _ interpreterProxy fetchInteger: 0 ofObject: srcOrigin.
	sourceY _ interpreterProxy fetchInteger: 1 ofObject: srcOrigin.
	destX _ interpreterProxy fetchInteger: 0 ofObject: dstOrigin.
	destY _ interpreterProxy fetchInteger: 1 ofObject: dstOrigin.
	interpreterProxy failed ifTrue:[^nil].
	result _ self cCode:'b3dxBltFromDisplay(displayHandle, formHandle, destX, destY, sourceX, sourceY, extentX, extentY)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 5. "pop args; return rcvr"