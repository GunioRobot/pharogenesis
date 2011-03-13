browserWindowColor
	^ self
		valueOfFlag: #browserWindowColor
		ifAbsent: [Color
				r: 0.8
				g: 1.0
				b: 0.6]