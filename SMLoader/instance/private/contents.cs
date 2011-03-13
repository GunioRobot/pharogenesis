contents
	| packageOrRelease |
	packageOrRelease := self selectedPackageOrRelease.
	^packageOrRelease
		ifNil: ['<No package selected>']
		ifNotNil: [packageOrRelease fullDescription]
