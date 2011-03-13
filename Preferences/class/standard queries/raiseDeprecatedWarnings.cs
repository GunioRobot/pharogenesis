raiseDeprecatedWarnings
	^ self
		valueOfFlag: #raiseDeprecatedWarnings
		ifAbsent: [true]