dualChangeSorterWindowColor
	^ self
		valueOfFlag: #dualChangeSorterWindowColor
		ifAbsent: [Color
				r: 0.8
				g: 1.0
				b: 1.0]