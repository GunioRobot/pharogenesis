primitiveGetBezierStats
	| statOop stats |
	self export: true.
	self inline: false.
	self var: #stats declareC:'int *stats'.

	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].

	statOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].

	(interpreterProxy isWords: statOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: statOop) < 4
		ifTrue:[^interpreterProxy primitiveFail].
	stats _ interpreterProxy firstIndexableField: statOop.
	stats at: 0 put: (stats at: 0) + (workBuffer at: GWBezierMonotonSubdivisions).
	stats at: 1 put: (stats at: 1) + (workBuffer at: GWBezierHeightSubdivisions).
	stats at: 2 put: (stats at: 2) + (workBuffer at: GWBezierOverflowSubdivisions).
	stats at: 3 put: (stats at: 3) + (workBuffer at: GWBezierLineConversions).

	interpreterProxy pop: 1. "Leave rcvr on stack"