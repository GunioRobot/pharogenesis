versionsBrowserWindowColor
	^ self
		valueOfFlag: #versionsBrowserWindowColor
		ifAbsent: [Color
				r: 0.869
				g: 0.753
				b: 1.0]