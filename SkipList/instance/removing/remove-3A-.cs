remove: element 
	^ self remove: element ifAbsent: [self errorNotFound: element]