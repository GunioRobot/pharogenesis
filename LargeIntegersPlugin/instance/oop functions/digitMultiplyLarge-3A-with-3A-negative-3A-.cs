digitMultiplyLarge: firstInteger with: secondInteger negative: neg 
	"Normalizes."
	| firstLen secondLen shortInt shortLen longInt longLen prod resultClass |
	firstLen _ self byteSizeOfBytes: firstInteger.
	secondLen _ self byteSizeOfBytes: secondInteger.
	firstLen <= secondLen
		ifTrue: 
			[shortInt _ firstInteger.
			shortLen _ firstLen.
			longInt _ secondInteger.
			longLen _ secondLen]
		ifFalse: 
			[shortInt _ secondInteger.
			shortLen _ secondLen.
			longInt _ firstInteger.
			longLen _ firstLen].
	neg
		ifTrue: [resultClass _ interpreterProxy classLargeNegativeInteger]
		ifFalse: [resultClass _ interpreterProxy classLargePositiveInteger].
	self remapOop: #(shortInt longInt ) in: [prod _ interpreterProxy instantiateClass: resultClass indexableSize: longLen + shortLen].
	self
		cDigitMultiply: (interpreterProxy firstIndexableField: shortInt)
		len: shortLen
		with: (interpreterProxy firstIndexableField: longInt)
		len: longLen
		into: (interpreterProxy firstIndexableField: prod).
	^ self normalize: prod