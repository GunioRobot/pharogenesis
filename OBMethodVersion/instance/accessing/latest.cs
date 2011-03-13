latest
	^ self class 
			fromSources: sources 
			andPointer: (classRef theClass compiledMethodAt: selector) sourcePointer