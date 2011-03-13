showDeprecationWarnings
	^ self
		valueOfFlag: #showDeprecationWarnings
		ifAbsent: [true]