indexOfSubCollection: sub startingAt: start ifAbsent: exceptionBlock
	| index |
	index _ self findSubstring: sub in: self startingAt: start matchTable: CaseSensitiveOrder.
	index = 0 ifTrue: [^ exceptionBlock value].
	^ index