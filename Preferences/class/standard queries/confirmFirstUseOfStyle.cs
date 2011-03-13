confirmFirstUseOfStyle
	^ self
		valueOfFlag: #confirmFirstUseOfStyle
		ifAbsent: [true]