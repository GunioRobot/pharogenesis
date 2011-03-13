endShape
	| points shape fillLists lineLists index |
	canCompressPoints ifTrue:[
		points := ShortPointArray new: pointList size.
	] ifFalse:[
		points := PointArray new: pointList size.
	].
	index := 1.
	pointList contents do:[:p|
		points at: index put: p.
		index := index + 1].

	fillLists := self computeFillLists.
	lineLists := self computeLineStyleLists.
	shape := FlashBoundaryShape 
				points: points 
				leftFills: fillLists first
				rightFills: fillLists last
				fillStyles: lineLists first
				lineWidths: lineLists last
				lineFills: (lineLists at: 2).
	shape remapFills.
	currentShape nextPut:(FlashShapeMorph shape: shape).