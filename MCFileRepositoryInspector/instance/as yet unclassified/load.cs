load
	self hasVersion ifTrue:
		[version workingCopy repositoryGroup addRepository: repository.
		super load].