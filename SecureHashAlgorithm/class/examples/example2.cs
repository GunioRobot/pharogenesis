example2
	"Here is the third example from the specification document (FIPS PUB 180-1). This example may take several minutes."
	"SecureHashAlgorithm example2"

	| hash |
	hash _ SecureHashAlgorithm new hashMessage: (String new: 1000000 withAll: $a).
	hash = 16r34AA973CD4C4DAA4F61EEB2BDBAD27316534016F
		ifTrue: [self inform: 'Passed Test #3']
		ifFalse: [self error: 'Test #3 failed!'].
