messageSelectors
	^ ((self theClass compiledMethodAt: self selector ifAbsent: [^ #()]) messages) asSortedArray