fenceSoundEnabled
	^ self
		valueOfFlag: #fenceSoundEnabled
		ifAbsent: [true]