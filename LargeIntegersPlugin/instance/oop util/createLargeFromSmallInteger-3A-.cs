createLargeFromSmallInteger: anOop 
	"anOop has to be a SmallInteger!"
	| val class size res pByte |
	self var: #pByte declareC: 'unsigned char *  pByte'.
	val _ interpreterProxy integerValueOf: anOop.
	val < 0
		ifTrue: [class _ interpreterProxy classLargeNegativeInteger]
		ifFalse: [class _ interpreterProxy classLargePositiveInteger].
	size _ self cDigitLengthOfCSI: val.
	res _ interpreterProxy instantiateClass: class indexableSize: size.
	pByte _ interpreterProxy firstIndexableField: res.
	1 to: size do: [:ix | pByte at: ix - 1 put: (self cDigitOfCSI: val at: ix)].
	^ res