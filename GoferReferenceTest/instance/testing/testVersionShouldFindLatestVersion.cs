testVersionShouldFindLatestVersion
	| versionReference otherReference |
	versionReference := GoferVersionReference name: 'Gofer-lr.18' repository: self goferRepository.
	otherReference := versionReference versionReference.
	self assert: versionReference packageName = 'Gofer'.
	self assert: versionReference authorName = 'lr'.
	self assert: versionReference versionNumber = 18.
	self assert: otherReference = versionReference.
	self assert: otherReference == versionReference