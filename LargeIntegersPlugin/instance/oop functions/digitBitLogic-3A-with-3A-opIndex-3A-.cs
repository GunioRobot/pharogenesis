digitBitLogic: firstInteger with: secondInteger opIndex: opIx 
	"Bit logic here is only implemented for positive integers or Zero;
	if rec or arg is negative, it fails."
	| firstLarge secondLarge firstLen secondLen shortLen shortLarge longLen longLarge result |
	(interpreterProxy isIntegerObject: firstInteger)
		ifTrue: 
			[(interpreterProxy integerValueOf: firstInteger)
				< 0 ifTrue: [^ interpreterProxy primitiveFail].
			"convert it to a not normalized LargeInteger"
			self remapOop: secondInteger in: [firstLarge _ self createLargeFromSmallInteger: firstInteger]]
		ifFalse: 
			[(interpreterProxy fetchClassOf: firstInteger)
				= interpreterProxy classLargeNegativeInteger ifTrue: [^ interpreterProxy primitiveFail].
			firstLarge _ firstInteger].
	(interpreterProxy isIntegerObject: secondInteger)
		ifTrue: 
			[(interpreterProxy integerValueOf: secondInteger)
				< 0 ifTrue: [^ interpreterProxy primitiveFail].
			"convert it to a not normalized LargeInteger"
			self remapOop: firstLarge in: [secondLarge _ self createLargeFromSmallInteger: secondInteger]]
		ifFalse: 
			[(interpreterProxy fetchClassOf: secondInteger)
				= interpreterProxy classLargeNegativeInteger ifTrue: [^ interpreterProxy primitiveFail].
			secondLarge _ secondInteger].
	firstLen _ self byteSizeOfBytes: firstLarge.
	secondLen _ self byteSizeOfBytes: secondLarge.
	firstLen < secondLen
		ifTrue: 
			[shortLen _ firstLen.
			shortLarge _ firstLarge.
			longLen _ secondLen.
			longLarge _ secondLarge]
		ifFalse: 
			[shortLen _ secondLen.
			shortLarge _ secondLarge.
			longLen _ firstLen.
			longLarge _ firstLarge].
	self remapOop: #(shortLarge longLarge ) in: [result _ interpreterProxy instantiateClass: interpreterProxy classLargePositiveInteger indexableSize: longLen].
	self
		cByteOp: opIx
		short: (interpreterProxy firstIndexableField: shortLarge)
		len: shortLen
		long: (interpreterProxy firstIndexableField: longLarge)
		len: longLen
		into: (interpreterProxy firstIndexableField: result).
	interpreterProxy failed ifTrue: [^ 0].
	^ self normalizePositive: result