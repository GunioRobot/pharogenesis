duplicateAllControlAndAltKeys
	^ self
		valueOfFlag: #duplicateAllControlAndAltKeys
		ifAbsent: [true]