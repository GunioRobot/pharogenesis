indexOfSubCollection: sub startingAt: start ifAbsent: exceptionBlock
	| index |
	index := self findSubstring: sub in: self startingAt: start matchTable: CaseSensitiveOrder.
	index = 0 ifTrue: [^ exceptionBlock value].
	^ index