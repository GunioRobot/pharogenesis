stackLightArrayValue: stackIndex
	"Load an Array of B3DPrimitiveLights from the given stack index"
	| oop array arraySize |
	self inline: false.
	array _ interpreterProxy stackObjectValue: stackIndex.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy fetchClassOf: array) = interpreterProxy classArray
		ifFalse:[^interpreterProxy primitiveFail].
	arraySize _ interpreterProxy slotSizeOf: array.
	0 to: arraySize-1 do:[:i|
		oop _ interpreterProxy fetchPointer: i ofObject: array.
		(interpreterProxy isIntegerObject: oop)
			ifTrue:[^interpreterProxy primitiveFail].
		((interpreterProxy isWords: oop) and:[(interpreterProxy slotSizeOf: oop) = PrimLightSize])
			ifFalse:[^interpreterProxy primitiveFail].
	].
	^array