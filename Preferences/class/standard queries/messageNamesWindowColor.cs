messageNamesWindowColor
	^ self
		valueOfFlag: #messageNamesWindowColor
		ifAbsent: [Color
				r: 0.645
				g: 1.0
				b: 0.452]