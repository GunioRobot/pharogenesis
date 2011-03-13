instanceBrowserWindowColor
	^ self
		valueOfFlag: #instanceBrowserWindowColor
		ifAbsent: [Color
				r: 0.806
				g: 1.0
				b: 1.0]