dynamicProtocolActivation
	^ self
		valueOfFlag: #dynamicProtocolActivation
		ifAbsent: [true]