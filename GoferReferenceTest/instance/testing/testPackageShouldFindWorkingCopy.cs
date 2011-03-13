testPackageShouldFindWorkingCopy
	| packageReference workingCopy |
	packageReference := GoferPackageReference name: 'Gofer'.
	workingCopy := packageReference workingCopy.
	self assert: workingCopy packageName = 'Gofer'