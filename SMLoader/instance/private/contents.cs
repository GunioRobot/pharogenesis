contents
	| packageOrRelease |
	packageOrRelease _ self selectedPackageOrRelease.
	^packageOrRelease
		ifNil: ['<No package selected>']
		ifNotNil: [packageOrRelease fullDescription]
