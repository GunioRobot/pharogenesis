positive64BitIntegerFor: integerValue

	| newLargeInteger value check |
	"Note - integerValue is interpreted as POSITIVE, eg, as the result of
		Bitmap>at:, or integer>bitAnd:."
	self var: 'integerValue' type: 'squeakInt64'.
 
	(self sizeof: integerValue) = 4 ifTrue: [^self positive32BitIntegerFor: integerValue].

  	self cCode: 'check = integerValue >> 32'.
	check = 0 ifTrue: [^self positive32BitIntegerFor: integerValue].
	
	newLargeInteger _
		self instantiateSmallClass: (self splObj: ClassLargePositiveInteger) sizeInBytes: 12 fill: 0.
	0 to: 7 do: [:i |
		self cCode: 'value = ( integerValue >> (i * 8)) & 255'.
		self storeByte: i ofObject: newLargeInteger withValue: value].
	^ newLargeInteger