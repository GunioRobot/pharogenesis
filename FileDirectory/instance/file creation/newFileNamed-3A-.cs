newFileNamed: fileName
	^ self fileClass newFileNamed: (self fullNameFor: fileName)