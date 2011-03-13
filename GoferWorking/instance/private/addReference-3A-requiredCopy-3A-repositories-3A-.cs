addReference: aPackage requiredCopy: aWorkingCopy repositories: anArray 
	(workingCopies includes: aWorkingCopy)
		ifTrue: [ ^ self ].
	workingCopies addLast: aWorkingCopy.
	aWorkingCopy requiredPackages
		reverseDo: [ :each | self addReference: aPackage requiredCopy: each workingCopy repositories: anArray ]