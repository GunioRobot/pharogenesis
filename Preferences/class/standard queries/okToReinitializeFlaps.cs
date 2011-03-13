okToReinitializeFlaps
	^ self
		valueOfFlag: #okToReinitializeFlaps
		ifAbsent: [true]