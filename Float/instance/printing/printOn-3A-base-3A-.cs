printOn: aStream base: base
	"Estimate significant figures and handle sign." 
	| digitCount |
	digitCount _ 2r1.0e23 "23 bits" floorLog: base asFloat.
	self > 0.0
		ifTrue: [self absPrintOn: aStream base: base digitCount: digitCount]
		ifFalse: [self = 0.0 ifTrue: [^ aStream nextPutAll: '0.0'].
				aStream nextPutAll: '-'.
				self negated absPrintOn: aStream base: base digitCount: digitCount]