signed64BitIntegerFor: integerValue
	"Return a Large Integer object for the given integer value"
	| newLargeInteger value largeClass intValue check |
	self inline: false.
	self var: 'integerValue' type: 'squeakInt64'.
	self var: 'value' type: 'squeakInt64'.
	integerValue < 0
		ifTrue:[	largeClass _ self classLargeNegativeInteger.
				value _ 0 - integerValue]
		ifFalse:[	largeClass _ self classLargePositiveInteger.
				value _ integerValue].

	(self sizeof: value) = 4 ifTrue: [^self signed32BitIntegerFor: integerValue].

	self cCode: 'check = value >> 32'.
	check = 0 ifTrue: [^self signed32BitIntegerFor: integerValue].

	newLargeInteger _ self instantiateSmallClass: largeClass sizeInBytes:  12 fill: 0.
	0 to: 7 do: [:i |
		self cCode: 'intValue = ( value >> (i * 8)) & 255'.
		self storeByte: i ofObject: newLargeInteger withValue: intValue].
	^ newLargeInteger