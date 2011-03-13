dismissAllOnOptionClose
	^ self
		valueOfFlag: #dismissAllOnOptionClose
		ifAbsent: [false]