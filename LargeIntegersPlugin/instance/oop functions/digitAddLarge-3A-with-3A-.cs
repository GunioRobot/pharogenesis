digitAddLarge: firstInteger with: secondInteger 
	"Does not need to normalize!"
	| over firstLen secondLen shortInt shortLen longInt longLen sum newSum resClass |
	self var: #over declareC: 'unsigned char  over'.
	firstLen _ self byteSizeOfBytes: firstInteger.
	secondLen _ self byteSizeOfBytes: secondInteger.
	resClass _ interpreterProxy fetchClassOf: firstInteger.
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
	"	sum _ Integer new: len neg: firstInteger negative."
	self remapOop: #(shortInt longInt ) in: [sum _ interpreterProxy instantiateClass: resClass indexableSize: longLen].
	over _ self
				cDigitAdd: (interpreterProxy firstIndexableField: shortInt)
				len: shortLen
				with: (interpreterProxy firstIndexableField: longInt)
				len: longLen
				into: (interpreterProxy firstIndexableField: sum).
	over > 0
		ifTrue: 
			["sum _ sum growby: 1."
			interpreterProxy remapOop: sum in: [newSum _ interpreterProxy instantiateClass: resClass indexableSize: longLen + 1].
			self
				cBytesCopyFrom: (interpreterProxy firstIndexableField: sum)
				to: (interpreterProxy firstIndexableField: newSum)
				len: longLen.
			sum _ newSum.
			"C index!"
			(self cCoerce: (interpreterProxy firstIndexableField: sum)
				to: 'unsigned char *')
				at: longLen put: over].
	^ sum