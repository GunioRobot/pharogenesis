editRepository
	| oldTemplate newRepo |
	
	oldTemplate _ self repository creationTemplate.
	oldTemplate ifNotNil: [ newRepo _ self repository openAndEditTemplateCopy ].
	newRepo ifNotNil: [ 
		self removeRepository.
		self addRepository: newRepo.
		self addRepositoryToWorkingCopy.
	].