loadViewportFrom: stackIndex
	"Load the viewport from the given stack index"
	| oop p1 p2 x0 y0 x1 y1 |
	oop _ interpreterProxy stackObjectValue: stackIndex.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isPointers: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: oop) < 2
		ifTrue:[^interpreterProxy primitiveFail].
	p1 _ interpreterProxy fetchPointer: 0 ofObject: oop.
	p2 _ interpreterProxy fetchPointer: 1 ofObject: oop.
	(interpreterProxy fetchClassOf: p1) = interpreterProxy classPoint
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy fetchClassOf: p2) = interpreterProxy classPoint
		ifFalse:[^interpreterProxy primitiveFail].
	x0 _ interpreterProxy fetchInteger: 0 ofObject: p1.
	y0 _ interpreterProxy fetchInteger: 1 ofObject: p1.
	x1 _ (interpreterProxy fetchInteger: 0 ofObject: p2).
	y1 _ (interpreterProxy fetchInteger: 1 ofObject: p2).
	interpreterProxy failed ifTrue:[^nil].
	self cCode:'viewport.x0 = x0'.
	self cCode:'viewport.y0 = y0'.
	self cCode:'viewport.x1 = x1'.
	self cCode:'viewport.y1 = y1'.
	^0