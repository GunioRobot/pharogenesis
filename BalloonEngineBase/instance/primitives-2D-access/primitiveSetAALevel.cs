primitiveSetAALevel
	| level |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].
	level _ interpreterProxy stackIntegerValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].
	self setAALevel: level.
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1. "Leace rcvr on stack"