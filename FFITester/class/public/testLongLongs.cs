testLongLongs	"FFITester testLongLongs"
	"Test passing and returning longlongs"
	| long1 long2 long3 |
	long1 _ 16r123456789012.
	long2 _ (-1 << 31).
	long3 _ self ffiTestLongLong: long1 with: long2.
	long3 = (long1 + long2) ifFalse:[self error:'Problem passing/returning longlongs'].
	^long3