primitiveRegisterExternalFill
	| index  fill |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 1 
		ifFalse:[^interpreterProxy primitiveFail].
	index _ interpreterProxy stackIntegerValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	"Note: We *must* not allocate any fill with index 0"
	fill _ 0.
	[fill = 0] whileTrue:[
		(self allocateObjEntry: GEBaseEdgeSize) 
			ifFalse:[^interpreterProxy primitiveFail].
		fill _ objUsed.
		objUsed _ fill + GEBaseFillSize.
		"Install type and length"
		self objectTypeOf: fill put: GEPrimitiveFill.
		self objectLengthOf: fill put: GEBaseFillSize.
		self objectIndexOf: fill put: index.
	].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 2.
		interpreterProxy pushInteger: fill.
	].