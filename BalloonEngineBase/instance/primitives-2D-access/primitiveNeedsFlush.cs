primitiveNeedsFlush
	| needFlush |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].
	needFlush _ self needsFlush.
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1.
	interpreterProxy pushBool: needFlush.

