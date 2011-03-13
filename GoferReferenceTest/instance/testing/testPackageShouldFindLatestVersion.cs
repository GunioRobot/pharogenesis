testPackageShouldFindLatestVersion
	| packageReference versionReference |
	packageReference := GoferPackageReference name: 'Gofer' repository: self goferRepository.
	versionReference := packageReference versionReference.
	self assert: versionReference packageName = 'Gofer'.
	self assert: versionReference versionNumber > 55