atCol: x put: aCollection
	"Put in a whole column."

	aCollection size = self height ifFalse: [self error: 'wrong column size'].
	aCollection doWithIndex: [:value :y | self at: x at: y put: value].
	^ aCollection