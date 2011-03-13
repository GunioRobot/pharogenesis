remove: oldObject ifAbsent: absentBlock

	| index |
	index _ firstIndex.
	[index <= lastIndex]
		whileTrue: 
			[oldObject = (array at: index)
				ifTrue: 
					[self removeIndex: index.
					^ oldObject]
				ifFalse: [index _ index + 1]].
	^ absentBlock value