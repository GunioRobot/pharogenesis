noWindowAnimationForClosing
	^ self
		valueOfFlag: #noWindowAnimationForClosing
		ifAbsent: [false]