primitiveSetEdgeTransform
	| transformOop |
	self export: true.	
	self inline: false.

	interpreterProxy methodArgumentCount = 1
		ifFalse:[^interpreterProxy primitiveFail].

	transformOop _ interpreterProxy stackObjectValue: 0.
	engine _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	self loadEdgeTransformFrom: transformOop.
	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 1. "Leave rcvr on stack"
	].