fetchIntOrFloat: index ofObject: oop ifNil: defaultValue
	| fieldOop floatValue |
	self var: #floatValue declareC:'double floatValue'.
	fieldOop _ interpreterProxy fetchPointer: index ofObject: oop.
	(fieldOop = interpreterProxy nilObject) ifTrue:[^defaultValue].
	(interpreterProxy isIntegerObject: fieldOop)
		ifTrue:[^interpreterProxy integerValueOf: fieldOop].
	floatValue _ interpreterProxy floatValueOf: fieldOop.
	(-2147483648.0 <= floatValue and:[floatValue <= 2147483647.0])
		ifFalse:[interpreterProxy primitiveFail].
	^floatValue asInteger