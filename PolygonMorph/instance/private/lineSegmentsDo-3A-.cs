lineSegmentsDo: endPointsBlock
	| beginPoint |
	beginPoint _ nil.
	vertices do:
		[:endPoint | beginPoint ifNotNil:
			[endPointsBlock value: beginPoint
							value: endPoint].
		beginPoint _ endPoint].
	(closed or: [vertices size = 1])
		ifTrue: [endPointsBlock value: beginPoint
								value: vertices first]