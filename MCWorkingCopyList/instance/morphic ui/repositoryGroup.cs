repositoryGroup
	^ workingCopy
		ifNil: [MCRepositoryGroup default]
		ifNotNil: [workingCopy repositoryGroup]