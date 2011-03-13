makeRoomAtFirst
	| delta index |
	delta _ array size - self size.
	delta = 0 ifTrue: 
			[self grow.
			delta _ array size - self size].
	lastIndex = array size ifTrue: [^ self]. "just in case we got lucky"
	index _ array size.
	[index > delta]
		whileTrue: 
			[array at: index put: (array at: index - delta + firstIndex - 1).
			array at: index - delta + firstIndex - 1 put: nil.
			index _ index - 1].
	firstIndex _ delta + 1.
	lastIndex _ array size