newFileNamed: fileName 
	^ self concreteStream newFileNamed: (self fullName: fileName)