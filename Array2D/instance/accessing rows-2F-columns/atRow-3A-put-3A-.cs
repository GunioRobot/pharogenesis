atRow: y put: aCollection
	"Put in a whole row."

	aCollection size = self width ifFalse: [self error: 'wrong row size'].
	aCollection doWithIndex: [:value :x | self at: x at: y put: value].
	^ aCollection