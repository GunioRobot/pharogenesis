scrollAbsolute: event
	| r p |
	r _ self roomToMove.
	p _ event targetPoint adhereTo: r.
	self setValue: (bounds isWide 
		ifTrue: [(p x - r left) asFloat / r width]
		ifFalse: [(p y - r top) asFloat / r height])