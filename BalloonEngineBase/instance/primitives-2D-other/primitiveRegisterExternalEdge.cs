primitiveRegisterExternalEdge
	| rightFillIndex leftFillIndex initialZ initialY initialX index  edge |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 6 
		ifFalse:[^interpreterProxy primitiveFail].
	rightFillIndex _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 0).
	leftFillIndex _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 1).
	initialZ _ interpreterProxy stackIntegerValue: 2.
	initialY _ interpreterProxy stackIntegerValue: 3.
	initialX _ interpreterProxy stackIntegerValue: 4.
	index _ interpreterProxy stackIntegerValue: 5.
	engine _ interpreterProxy stackObjectValue: 6.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine requiredState: GEStateUnlocked)
		ifFalse:[^interpreterProxy primitiveFail].

	(self allocateObjEntry: GEBaseEdgeSize) 
		ifFalse:[^interpreterProxy primitiveFail].

	"Make sure the fills are okay"
	(self isFillOkay: leftFillIndex)
		ifFalse:[^interpreterProxy primitiveFail].
	(self isFillOkay: rightFillIndex)
		ifFalse:[^interpreterProxy primitiveFail].

	edge _ objUsed.
	objUsed _ edge + GEBaseEdgeSize.
	"Install type and length"
	self objectTypeOf: edge put: GEPrimitiveEdge.
	self objectLengthOf: edge put: GEBaseEdgeSize.
	self objectIndexOf: edge put: index.
	"Install remaining stuff"
	self edgeXValueOf: edge put: initialX.
	self edgeYValueOf: edge put: initialY.
	self edgeZValueOf: edge put: initialZ.
	self edgeLeftFillOf: edge put: (self transformColor: leftFillIndex).
	self edgeRightFillOf: edge put: (self transformColor: rightFillIndex).
	engineStopped ifTrue:[^interpreterProxy primitiveFail].

	interpreterProxy failed ifFalse:[
		self storeEngineStateInto: engine.
		interpreterProxy pop: 6. "Leave rcvr on stack"
	].