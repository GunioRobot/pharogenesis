roundAndStoreResultRect: dstOop x0: x0 y0: y0 x1: x1 y1: y1
	"Check, round and store the result of a rectangle operation"
	| minX maxX minY maxY originOop cornerOop rectOop |
	self var: #x0 declareC:'double x0'.
	self var: #y0 declareC:'double y0'.
	self var: #x1 declareC:'double x1'.
	self var: #y1 declareC:'double y1'.
	self var: #minX declareC:'double minX'.
	self var: #maxX declareC:'double maxX'.
	self var: #minY declareC:'double minY'.
	self var: #maxY declareC:'double maxY'.

	minX _ x0 + 0.5.
	(self okayIntValue: minX) ifFalse:[^interpreterProxy primitiveFail].
	maxX _ x1 + 0.5.
	(self okayIntValue: maxX) ifFalse:[^interpreterProxy primitiveFail].
	minY _ y0 + 0.5.
	(self okayIntValue: minY) ifFalse:[^interpreterProxy primitiveFail].
	maxY _ y1 + 0.5.
	(self okayIntValue: maxY) ifFalse:[^interpreterProxy primitiveFail].

	interpreterProxy pushRemappableOop: dstOop.
	originOop _ interpreterProxy makePointwithxValue: minX asInteger yValue: minY asInteger.
	interpreterProxy pushRemappableOop: originOop.
	cornerOop _ interpreterProxy makePointwithxValue: maxX asInteger yValue: maxY asInteger.
	originOop _ interpreterProxy popRemappableOop.
	rectOop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: rectOop withValue: originOop.
	interpreterProxy storePointer: 1 ofObject: rectOop withValue: cornerOop.
	^rectOop