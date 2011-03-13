testBounds
	"self run: #testBounds"
	
	self should: [Delay forMilliseconds: -1] raise: Error.
	self should: [Delay forMilliseconds: SmallInteger maxVal // 2 + 1] raise: Error. "Not longer than a day"
	self shouldnt: [Delay forMilliseconds: SmallInteger maxVal // 2] raise: Error.
	self shouldnt: [(Delay forMilliseconds: Float pi) wait] raise: Error. "Wait 3ms"
