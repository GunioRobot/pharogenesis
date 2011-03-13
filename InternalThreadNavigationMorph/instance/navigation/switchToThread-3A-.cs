switchToThread: newName

	threadName _ newName.
	listOfPages _ self class knownThreads at: threadName.
	self removeAllMorphs.
	self addButtons.
	self currentIndex.
