signed32BitIntegerFor: integerValue
	"Return a full 32 bit integer object for the given integer value"
	| newLargeInteger value largeClass |
	self inline: false.
	(self isIntegerValue: integerValue)
		ifTrue: [^ self integerObjectOf: integerValue].
	integerValue < 0
		ifTrue:[	largeClass _ self classLargeNegativeInteger.
				value _ 0 - integerValue]
		ifFalse:[	largeClass _ self classLargePositiveInteger.
				value _ integerValue].
	newLargeInteger _ self instantiateClass: largeClass indexableSize: 4.
	self storeByte: 3 ofObject: newLargeInteger withValue: ((value >> 24) bitAnd: 16rFF).
	self storeByte: 2 ofObject: newLargeInteger withValue: ((value >> 16) bitAnd: 16rFF).
	self storeByte: 1 ofObject: newLargeInteger withValue: ((value >> 8) bitAnd: 16rFF).
	self storeByte: 0 ofObject: newLargeInteger withValue: (value bitAnd: 16rFF).
	^ newLargeInteger