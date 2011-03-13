keepTickingWhilePainting
	^ self
		valueOfFlag: #keepTickingWhilePainting
		ifAbsent: [false]