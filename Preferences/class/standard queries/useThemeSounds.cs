useThemeSounds
	^ self
		valueOfFlag: #useThemeSounds
		ifAbsent: [true]