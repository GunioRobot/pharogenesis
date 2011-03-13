repository: aRepository
	"Set the repository aRepository as the location for the following package additions."

	MCRepositoryGroup default
		addRepository: aRepository.
	repository := MCRepositoryGroup default repositories
		detect: [ :each | each = aRepository ]
		ifNone: [ self error: 'Internal error' ].
	repository copyFrom: aRepository