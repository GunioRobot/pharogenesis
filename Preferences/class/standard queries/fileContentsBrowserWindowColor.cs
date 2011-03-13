fileContentsBrowserWindowColor
	^ self
		valueOfFlag: #fileContentsBrowserWindowColor
		ifAbsent: [Color
				r: 0.8
				g: 0.8
				b: 0.5]