goToNextCard
	| index totalInstances originalIndex |
	self isStackLike ifFalse: [^ self].
	originalIndex _ (dataInstances indexOf: currentDataInstance).
	index _ originalIndex + 1.
	((totalInstances _ dataInstances size) >= index) ifFalse: 
		[(self doWrap and: [totalInstances > 1]) ifFalse: [^ self beep] ifTrue: [index _ 1]].

	self installAsCurrent: (dataInstances at: index)