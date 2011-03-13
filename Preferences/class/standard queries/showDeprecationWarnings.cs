showDeprecationWarnings
	^ self
		valueOfFlag: #showDeprecationWarnings
		ifAbsent: [false]