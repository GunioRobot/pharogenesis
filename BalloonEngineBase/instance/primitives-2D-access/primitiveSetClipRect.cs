primitiveSetClipRect
	| rectOop |
	self export: true.	
	self inline: false.

	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].

	rectOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	(interpreterProxy isPointers: rectOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: rectOop) < 2
		ifTrue:[^interpreterProxy primitiveFail].
	self loadPoint: self point1Get from: (interpreterProxy fetchPointer: 0 ofObject: rectOop).
	self loadPoint: self point2Get from: (interpreterProxy fetchPointer: 1 ofObject: rectOop).
	interpreterProxy failed ifFalse:[
		self clipMinXPut: (self point1Get at: 0).
		self clipMinYPut: (self point1Get at: 1).
		self clipMaxXPut: (self point2Get at: 0).
		self clipMaxYPut: (self point2Get at: 1).
		self storeEngineStateInto: engine.
		interpreterProxy pop: 1. "Leave rcvr on stack"
	].