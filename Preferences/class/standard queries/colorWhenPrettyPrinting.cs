colorWhenPrettyPrinting
	^ self
		valueOfFlag: #colorWhenPrettyPrinting
		ifAbsent: [false]