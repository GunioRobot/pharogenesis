endShape
	| points shape fillLists lineLists index |
	canCompressPoints ifTrue:[
		points _ ShortPointArray new: pointList size.
	] ifFalse:[
		points _ PointArray new: pointList size.
	].
	index _ 1.
	pointList contents do:[:p|
		points at: index put: p.
		index _ index + 1].

	fillLists _ self computeFillLists.
	lineLists _ self computeLineStyleLists.
	shape _ FlashBoundaryShape 
				points: points 
				leftFills: fillLists first
				rightFills: fillLists last
				fillStyles: lineLists first
				lineWidths: lineLists last
				lineFills: (lineLists at: 2).
	shape remapFills.
	currentShape nextPut:(FlashShapeMorph shape: shape).