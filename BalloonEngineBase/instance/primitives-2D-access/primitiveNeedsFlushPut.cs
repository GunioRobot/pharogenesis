primitiveNeedsFlushPut
	| needFlush |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	needFlush _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	needFlush _ interpreterProxy booleanValueOf: needFlush.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].
	needFlush == true 
		ifTrue:[self needsFlushPut: 1]
		ifFalse:[self needsFlushPut: 0].
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1. "Leave rcvr on stack"
