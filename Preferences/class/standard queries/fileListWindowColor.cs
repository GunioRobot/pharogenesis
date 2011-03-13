fileListWindowColor
	^ self
		valueOfFlag: #fileListWindowColor
		ifAbsent: [Color
				r: 1.0
				g: 0.8
				b: 1.0]