readOnlyFileNamed: fileName
	^ self fileClass readOnlyFileNamed: (self fullNameFor: fileName)