loadPoint: pointArray from: pointOop
	"Load the contents of pointOop into pointArray"
	| value |
	self inline: false.
	self var: #pointArray declareC:'int *pointArray'.
	(interpreterProxy fetchClassOf: pointOop) = interpreterProxy classPoint 
		ifFalse:[^interpreterProxy primitiveFail].
	value _ interpreterProxy fetchPointer: 0 ofObject: pointOop.
	((interpreterProxy isIntegerObject: value) or:[interpreterProxy isFloatObject: value])
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy isIntegerObject: value)
		ifTrue:[pointArray at: 0 put: (interpreterProxy integerValueOf: value)]
		ifFalse:[pointArray at: 0 put: (interpreterProxy floatValueOf: value) asInteger].
	value _ interpreterProxy fetchPointer: 1 ofObject: pointOop.
	((interpreterProxy isIntegerObject: value) or:[interpreterProxy isFloatObject: value])
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy isIntegerObject: value)
		ifTrue:[pointArray at: 1 put: (interpreterProxy integerValueOf: value)]
		ifFalse:[pointArray at: 1 put: (interpreterProxy floatValueOf: value) asInteger].
