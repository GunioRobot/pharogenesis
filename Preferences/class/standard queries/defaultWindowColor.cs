defaultWindowColor
	^ self
		valueOfFlag: #defaultWindowColor
		ifAbsent: [Color
				r: 1.0
				g: 1.0
				b: 1.0]