digitSubLarge: firstInteger with: secondInteger 
	"Normalizes."
	| firstLen secondLen class larger largerLen smaller smallerLen neg resLen res firstNeg |
	firstNeg _ (interpreterProxy fetchClassOf: firstInteger)
				= interpreterProxy classLargeNegativeInteger.
	firstLen _ self byteSizeOfBytes: firstInteger.
	secondLen _ self byteSizeOfBytes: secondInteger.
	firstLen = secondLen
		ifTrue: 
			[[(self digitOfBytes: firstInteger at: firstLen)
				= (self digitOfBytes: secondInteger at: firstLen) and: [firstLen > 1]]
				whileTrue: [firstLen _ firstLen - 1].
			secondLen _ firstLen].
	(firstLen < secondLen
		or: [firstLen = secondLen and: [(self digitOfBytes: firstInteger at: firstLen)
					< (self digitOfBytes: secondInteger at: firstLen)]])
		ifTrue: 
			[larger _ secondInteger.
			largerLen _ secondLen.
			smaller _ firstInteger.
			smallerLen _ firstLen.
			neg _ firstNeg == false]
		ifFalse: 
			[larger _ firstInteger.
			largerLen _ firstLen.
			smaller _ secondInteger.
			smallerLen _ secondLen.
			neg _ firstNeg].
	resLen _ largerLen.
	neg
		ifTrue: [class _ interpreterProxy classLargeNegativeInteger]
		ifFalse: [class _ interpreterProxy classLargePositiveInteger].
	self remapOop: #(smaller larger ) in: [res _ interpreterProxy instantiateClass: class indexableSize: resLen].
	self
		cDigitSub: (interpreterProxy firstIndexableField: smaller)
		len: smallerLen
		with: (interpreterProxy firstIndexableField: larger)
		len: largerLen
		into: (interpreterProxy firstIndexableField: res).
	^ self normalize: res