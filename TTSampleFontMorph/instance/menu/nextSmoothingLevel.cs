nextSmoothingLevel
	smoothing = 1
		ifTrue: [smoothing _ 2]
		ifFalse: [smoothing = 2
			ifTrue: [smoothing _ 4]
			ifFalse: [smoothing = 4
				ifTrue: [smoothing _ 1]]].
	self changed