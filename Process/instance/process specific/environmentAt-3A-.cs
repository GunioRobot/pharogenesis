environmentAt: key 
	^ self environmentAt: key ifAbsent: [self environmentKeyNotFound]