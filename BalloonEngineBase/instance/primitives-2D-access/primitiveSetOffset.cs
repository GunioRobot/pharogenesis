primitiveSetOffset
	| pointOop |
	self export: true.	
	self inline: false.

	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].

	pointOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy fetchClassOf: pointOop) = interpreterProxy classPoint
		ifFalse:[^interpreterProxy primitiveFail].
	self loadPoint: self point1Get from: pointOop.
	interpreterProxy failed ifFalse:[
		self destOffsetXPut: (self point1Get at: 0).
		self destOffsetYPut: (self point1Get at: 1).
		self storeEngineStateInto: engine.
		interpreterProxy pop: 1. "Leave rcvr on stack"
	].