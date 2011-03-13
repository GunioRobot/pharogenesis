methodFinderWindowColor
	^ self
		valueOfFlag: #methodFinderWindowColor
		ifAbsent: [Color
				r: 0.4
				g: 1.0
				b: 1.0]