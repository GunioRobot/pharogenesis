primitiveGetAALevel
	self export: true.	
	self inline: false.
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: self aaLevelGet.