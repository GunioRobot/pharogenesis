loadArgumentPoint: point
	"Load the argument point into m23ArgX and m23ArgY"
	| oop isInt |
	interpreterProxy failed ifTrue:[^nil].
	"Check class of point"
	(interpreterProxy fetchClassOf: point) = (interpreterProxy classPoint) 
		ifFalse:[^interpreterProxy primitiveFail].
	"Load X value"
	oop _ interpreterProxy fetchPointer: 0 ofObject: point.
	isInt _ interpreterProxy isIntegerObject: oop.
	(isInt or:[interpreterProxy isFloatObject: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	isInt
		ifTrue:[m23ArgX _ interpreterProxy integerValueOf: oop]
		ifFalse:[m23ArgX _ interpreterProxy floatValueOf: oop].

	"Load Y value"
	oop _ interpreterProxy fetchPointer: 1 ofObject: point.
	isInt _ interpreterProxy isIntegerObject: oop.
	(isInt or:[interpreterProxy isFloatObject: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	isInt
		ifTrue:[m23ArgY _ interpreterProxy integerValueOf: oop]
		ifFalse:[m23ArgY _ interpreterProxy floatValueOf: oop].

