positive32BitIntegerFor: integerValue

	| newLargeInteger |
	"Note - integerValue is interpreted as POSITIVE, eg, as the result of
		Bitmap>at:, or integer>bitAnd:."
	(integerValue >= 0 and: [self isIntegerValue: integerValue])
		ifTrue: [^ self integerObjectOf: integerValue].
	newLargeInteger _
		self instantiateSmallClass: (self splObj: ClassLargePositiveInteger)
				sizeInBytes: 8
						 fill: 0.
	self storeByte: 3 ofObject: newLargeInteger
		withValue: ((integerValue >> 24) bitAnd: 16rFF).
	self storeByte: 2 ofObject: newLargeInteger
		withValue: ((integerValue >> 16) bitAnd: 16rFF).
	self storeByte: 1 ofObject: newLargeInteger
		withValue: ((integerValue >> 8) bitAnd: 16rFF).
	self storeByte: 0 ofObject: newLargeInteger
		withValue: (integerValue bitAnd: 16rFF).
	^ newLargeInteger