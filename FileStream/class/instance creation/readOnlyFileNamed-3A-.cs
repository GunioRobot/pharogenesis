readOnlyFileNamed: fileName 
	^ StandardFileStream readOnlyFileNamed: (self fullName: fileName)