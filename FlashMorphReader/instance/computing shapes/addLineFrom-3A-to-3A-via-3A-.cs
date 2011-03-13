addLineFrom: start to: end via: via

	canCompressPoints ifTrue:[
		"Check if we can compress the incoming points"
		(compressionBounds containsPoint: start) ifFalse:[canCompressPoints := false].
		(compressionBounds containsPoint: via) ifFalse:[canCompressPoints := false].
		(compressionBounds containsPoint: end) ifFalse:[canCompressPoints := false].
	].
	pointList nextPut: start.
	pointList nextPut: via.
	pointList nextPut: end.
	leftFillList nextPut: fillIndex0.
	rightFillList nextPut: fillIndex1.
	lineStyleList nextPut: lineStyleIndex.
