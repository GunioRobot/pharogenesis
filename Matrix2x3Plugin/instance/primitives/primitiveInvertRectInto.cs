primitiveInvertRectInto
	| matrix srcOop dstOop originX originY cornerX cornerY minX maxX minY maxY |
	self export: true.
	self inline: false.
	self var: #matrix declareC:'float *matrix'.
	self var: #originX declareC:'double originX'.
	self var: #originY declareC:'double originY'.
	self var: #cornerX declareC:'double cornerX'.
	self var: #cornerY declareC:'double cornerY'.
	self var: #minX declareC:'double minX'.
	self var: #maxX declareC:'double maxX'.
	self var: #minY declareC:'double minY'.
	self var: #maxY declareC:'double maxY'.

	dstOop _ interpreterProxy stackObjectValue: 0.
	srcOop _ interpreterProxy stackObjectValue: 1.
	matrix _ self loadArgumentMatrix: (interpreterProxy stackObjectValue: 2).
	interpreterProxy failed ifTrue:[^nil].

	(interpreterProxy fetchClassOf: srcOop) = (interpreterProxy fetchClassOf: dstOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy isPointers: srcOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: srcOop) = 2
		ifFalse:[^interpreterProxy primitiveFail].

	"Load top-left point"
	self loadArgumentPoint: (interpreterProxy fetchPointer: 0 ofObject: srcOop).
	interpreterProxy failed ifTrue:[^nil].
	originX _ m23ArgX.
	originY _ m23ArgY.
	self matrix2x3InvertPoint: matrix.
	minX _ maxX _ m23ResultX.
	minY _ maxY _ m23ResultY.

	"Load bottom-right point"
	self loadArgumentPoint:(interpreterProxy fetchPointer: 1 ofObject: srcOop).
	interpreterProxy failed ifTrue:[^nil].
	cornerX _ m23ArgX.
	cornerY _ m23ArgY.
	self matrix2x3InvertPoint: matrix.
	minX _ minX min: m23ResultX.
	maxX _ maxX max: m23ResultX.
	minY _ minY min: m23ResultY.
	maxY _ maxY max: m23ResultY.

	"Load top-right point"
	m23ArgX _ cornerX.
	m23ArgY _ originY.
	self matrix2x3InvertPoint: matrix.
	minX _ minX min: m23ResultX.
	maxX _ maxX max: m23ResultX.
	minY _ minY min: m23ResultY.
	maxY _ maxY max: m23ResultY.

	"Load bottom-left point"
	m23ArgX _ originX.
	m23ArgY _ cornerY.
	self matrix2x3InvertPoint: matrix.
	minX _ minX min: m23ResultX.
	maxX _ maxX max: m23ResultX.
	minY _ minY min: m23ResultY.
	maxY _ maxY max: m23ResultY.

	interpreterProxy failed ifFalse:[
		dstOop _ self roundAndStoreResultRect: dstOop x0: minX y0: minY x1: maxX y1: maxY].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 3.
		interpreterProxy push: dstOop.
	].