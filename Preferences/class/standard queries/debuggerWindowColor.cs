debuggerWindowColor
	^ self
		valueOfFlag: #debuggerWindowColor
		ifAbsent: [Color
				r: 1.0
				g: 0.8
				b: 0.8]