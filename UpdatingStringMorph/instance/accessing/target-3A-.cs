target: anObject

	target _ anObject.
	getSelector ifNotNil: [floatPrecision _ anObject defaultFloatPrecisionFor: getSelector]
