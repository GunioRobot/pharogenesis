packageBrowserWindowColor
	^ self
		valueOfFlag: #packageBrowserWindowColor
		ifAbsent: [Color
				r: 1.0
				g: 1.0
				b: 0.6]