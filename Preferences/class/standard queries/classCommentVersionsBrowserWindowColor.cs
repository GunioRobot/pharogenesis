classCommentVersionsBrowserWindowColor
	^ self
		valueOfFlag: #classCommentVersionsBrowserWindowColor
		ifAbsent: [Color
				r: 0.769
				g: 0.653
				b: 1.0]