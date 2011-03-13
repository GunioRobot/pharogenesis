keepTasklistOpen
	^ self
		valueOfFlag: #keepTasklistOpen
		ifAbsent: [false]