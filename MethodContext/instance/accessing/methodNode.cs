methodNode

	| h |
	^ self isExecutingBlock
		ifTrue: [self method blockNodeIn: ((h _ self blockHome) ifNotNil: [h methodNode])]
		ifFalse: [super methodNode]