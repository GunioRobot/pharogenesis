loadShape: points nSegments: nSegments fill: fillIndex lineWidth: lineWidth lineFill: lineFill  pointsShort: pointsShort
	self inline: false.
	self var:#points declareC:'int *points'.
	1 to: nSegments do:[:i|
		self loadCompressedSegment: i-1
			from: points
			short: pointsShort
			leftFill: fillIndex
			rightFill: 0
			lineWidth: lineWidth
			lineColor: lineFill.
		engineStopped ifTrue:[^nil].
	].