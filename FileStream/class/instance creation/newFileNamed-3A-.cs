newFileNamed: fileName 
	^ StandardFileStream newFileNamed: (self fullName: fileName)