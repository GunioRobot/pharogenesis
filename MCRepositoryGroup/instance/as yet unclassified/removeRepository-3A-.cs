removeRepository: aRepository
	repositories remove: aRepository ifAbsent: [].
	self changed: #repositories