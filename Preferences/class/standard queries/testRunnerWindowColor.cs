testRunnerWindowColor
	^ self
		valueOfFlag: #testRunnerWindowColor
		ifAbsent: [Color
				r: 0.65
				g: 0.753
				b: 0.976]