printOn: aStream base: base
	"Estimate significant figures and handle sign." 
	| digitCount potentialSigBits |
	self isNaN ifTrue: [^ aStream nextPutAll: 'NaN']. "check for NaN before sign"
	potentialSigBits _ 52 min: (1078 + self exponent). "reduce bits for denorms"
	digitCount _ (2 raisedTo: potentialSigBits) floorLog: base asFloat.  "IEEE double -- 52 bits"
	self > 0.0
		ifTrue: [self absPrintOn: aStream base: base digitCount: digitCount]
		ifFalse: [self = 0.0 ifTrue: [^ aStream nextPutAll: '0.0'].
				aStream nextPutAll: '-'.
				self negated absPrintOn: aStream base: base digitCount: digitCount]