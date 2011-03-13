goToPreviousCard
	| index totalInstances originalIndex |
	self isStackLike ifFalse: [^ self].
	originalIndex _ (dataInstances indexOf: currentDataInstance).
	index _ originalIndex - 1.
	(index > 0) ifFalse: 
		[totalInstances _ dataInstances size.
		(self doWrap and: [totalInstances > 1]) ifFalse: [^ self beep] ifTrue: [index _ totalInstances]].

	self installAsCurrent: (dataInstances at: index)