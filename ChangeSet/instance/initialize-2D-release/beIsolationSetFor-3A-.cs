beIsolationSetFor: aProject

	self isEmpty ifFalse: [self error: 'Must be empty at the start.'].
	isolatedProject _ aProject.
	revertable _ true.