ffiIntegerValueOf: oop
	"Support for generic callout. Return an integer value that is coerced as C would do."
	| oopClass |
	self inline: true.
	(interpreterProxy isIntegerObject: oop) ifTrue:[^interpreterProxy integerValueOf: oop].
	oop == interpreterProxy nilObject ifTrue:[^0]. "@@: should we really allow this????"
	oop == interpreterProxy falseObject ifTrue:[^0].
	oop == interpreterProxy trueObject ifTrue:[^1].
	oopClass _ interpreterProxy fetchClassOf: oop.
	oopClass == interpreterProxy classFloat
		ifTrue:[^(interpreterProxy floatValueOf: oop) asInteger].
	oopClass == interpreterProxy classCharacter
		ifTrue:[^interpreterProxy fetchInteger: 0 ofObject: oop].
	^interpreterProxy signed32BitValueOf: oop "<- will fail if not integer"