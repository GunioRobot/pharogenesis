loadTransformFrom: transformOop into: destPtr length: n
	"Load a transformation from transformOop into the float array
	defined by destPtr. The transformation is assumed to be either
	an array or a FloatArray of length n."
	self inline: false.
	self var: #destPtr declareC:'float *destPtr'.
	transformOop = interpreterProxy nilObject ifTrue:[^false].
	(interpreterProxy isIntegerObject: transformOop)
		ifTrue:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: transformOop) = n 
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy isWords: transformOop) 
		ifTrue:[self loadWordTransformFrom: transformOop into: destPtr length: n]
		ifFalse:[self loadArrayTransformFrom: transformOop into: destPtr length: n].
	^true