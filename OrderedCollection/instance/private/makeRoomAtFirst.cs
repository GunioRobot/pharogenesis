makeRoomAtFirst
	| delta index |
	delta := array size - self size.
	delta = 0 ifTrue: 
			[self grow.
			delta := array size - self size].
	lastIndex = array size ifTrue: [^ self]. "just in case we got lucky"
	index := array size.
	[index > delta]
		whileTrue: 
			[array at: index put: (array at: index - delta + firstIndex - 1).
			array at: index - delta + firstIndex - 1 put: nil.
			index := index - 1].
	firstIndex := delta + 1.
	lastIndex := array size