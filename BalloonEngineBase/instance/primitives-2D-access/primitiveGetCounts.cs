primitiveGetCounts
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
	(interpreterProxy slotSizeOf: statOop) < 9
		ifTrue:[^interpreterProxy primitiveFail].
	stats _ interpreterProxy firstIndexableField: statOop.
	stats at: 0 put: (stats at: 0) + (workBuffer at: GWCountInitializing).
	stats at: 1 put: (stats at: 1) + (workBuffer at: GWCountFinishTest).
	stats at: 2 put: (stats at: 2) + (workBuffer at: GWCountNextGETEntry).
	stats at: 3 put: (stats at: 3) + (workBuffer at: GWCountAddAETEntry).
	stats at: 4 put: (stats at: 4) + (workBuffer at: GWCountNextFillEntry).
	stats at: 5 put: (stats at: 5) + (workBuffer at: GWCountMergeFill).
	stats at: 6 put: (stats at: 6) + (workBuffer at: GWCountDisplaySpan).
	stats at: 7 put: (stats at: 7) + (workBuffer at: GWCountNextAETEntry).
	stats at: 8 put: (stats at: 8) + (workBuffer at: GWCountChangeAETEntry).

	interpreterProxy pop: 1. "Leave rcvr on stack"