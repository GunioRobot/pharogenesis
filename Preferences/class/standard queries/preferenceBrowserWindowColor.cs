preferenceBrowserWindowColor
	^ self
		valueOfFlag: #preferenceBrowserWindowColor
		ifAbsent: [Color
				r: 0.645
				g: 1.0
				b: 1.0]