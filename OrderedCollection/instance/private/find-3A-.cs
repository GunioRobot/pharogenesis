find: oldObject
	| index |
	index _ firstIndex.
	[index <= lastIndex and: [oldObject ~= (array at: index)]]
		whileTrue: [index _ index + 1].
	index <= lastIndex
		ifTrue: [^ index]
		ifFalse: [self errorNotFound]