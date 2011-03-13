scriptPerformer
	^ self isStackLike
		ifTrue:
			[currentDataInstance]
		ifFalse:
			[super scriptPerformer]