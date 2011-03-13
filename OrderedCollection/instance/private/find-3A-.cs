find: oldObject
	| index |
	index _ firstIndex.
	[index <= lastIndex]
		whileTrue:
			[(array at: index) = oldObject ifTrue: [^ index].
			index _ index + 1].
	self errorNotFound: oldObject