load
	self hasVersion ifTrue:
		[super load.
		version workingCopy repositoryGroup addRepository: repository].