ancestorInfo
	^ ancestorInfo ifNil: [ancestorInfo _ version info commonAncestorWith: version workingCopy ancestry]