FreeTypeCacheSize
	^ self
		valueOfFlag: #FreeTypeCacheSize
		ifAbsent: [5000]