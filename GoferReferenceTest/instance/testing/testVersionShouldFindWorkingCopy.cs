testVersionShouldFindWorkingCopy
	| versionReference workingCopy |
	versionReference := GoferVersionReference name: 'Gofer-lr.18' repository: self goferRepository.
	workingCopy := versionReference workingCopy.
	self assert: workingCopy packageName = 'Gofer'