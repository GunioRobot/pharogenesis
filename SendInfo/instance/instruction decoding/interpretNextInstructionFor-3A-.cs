interpretNextInstructionFor: client 
	self atMergePoint
		ifTrue: [self mergeStacks].
	super interpretNextInstructionFor: client