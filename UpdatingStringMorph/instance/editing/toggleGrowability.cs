toggleGrowability
	growable _ self growable not.
	self updateContentsFrom: self readFromTarget.
	growable ifTrue: [self fitContents]