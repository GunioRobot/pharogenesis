stepToFirstScanLineAt: yValue in: edgeTableEntry
	"Compute the initial x value for the scan line at yValue"
	|  startX endX startY endY yDir deltaY deltaX widthX |
	(start y) <= (end y) ifTrue:[
		startX _ start x.	endX _ end x.
		startY _ start y.	endY _ end y.
		yDir _ 1.
	] ifFalse:[
		startX _ end x.	endX _ start x.
		startY _ end y.	endY _ start y.
		yDir _ -1.
	].

	deltaY _ endY - startY.
	deltaX _ endX - startX.

	"Quickly check if the line is visible at all"
	(yValue >= endY or:[deltaY = 0]) ifTrue:[^edgeTableEntry lines: 0].

	"Check if edge goes left to right"
	deltaX >= 0 ifTrue:[
		xDirection _ 1.
		widthX _ deltaX.
		error _ 0.
	] ifFalse:[
		xDirection _ -1.
		widthX _ 0 - deltaX.
		error _ 1 - deltaY.
	].

	"Check if edge is horizontal"
	deltaY = 0 
		ifTrue:[	xIncrement _ 0.
				errorAdjUp _ 0]
		ifFalse:["Check if edge is y-major"
			deltaY > widthX 
				ifTrue:[	xIncrement _ 0.
						errorAdjUp _ widthX]
				ifFalse:[	xIncrement _ (widthX // deltaY) * xDirection.
						errorAdjUp _ widthX \\ deltaY]].

	errorAdjDown _ deltaY.

	edgeTableEntry xValue: startX.
	edgeTableEntry lines: deltaY.

	"If not at first scan line then step down to yValue"
	yValue = startY ifFalse:[
		startY to: yValue do:[:y| self stepToNextScanLineAt: y in: edgeTableEntry].
		"And adjust remainingLines"
		edgeTableEntry lines: deltaY - (yValue - startY).
	].