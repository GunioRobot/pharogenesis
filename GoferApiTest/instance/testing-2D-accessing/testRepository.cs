testRepository
	gofer repository: MCDirectoryRepository new.
	self assert: (gofer repository isKindOf: MCDirectoryRepository)