removeIndex: removedIndex
	| index |
	index _ removedIndex.
	[index < lastIndex]
		whileTrue: 
			[array at: index put: (array at: index + 1).
			index _ index + 1].
	array at: lastIndex put: nil.
	lastIndex _ lastIndex - 1