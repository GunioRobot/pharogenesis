stepToFirstLineIn: line at: yValue
	"Initialize the line at yValue"
	| deltaX deltaY xDir widthX error xInc errorAdjUp startY |
	self inline: false.

	"Do a quick check if there is anything at all to do"
	((self isWide: line) not and:[yValue >= (self lineEndYOf: line)])
		ifTrue:[^self edgeNumLinesOf: line put: 0].

	deltaX _ (self lineEndXOf: line) - (self edgeXValueOf: line).
	deltaY _ (self lineEndYOf: line) - (self edgeYValueOf: line).

	"Check if edge goes left to right"
	deltaX >= 0 
		ifTrue:[	xDir _ 1.
				widthX _ deltaX.
				error _ 0]
		ifFalse:[	xDir _ -1.
				widthX _ 0 - deltaX.
				error _ 1 - deltaY].

	"Check if deltaY is zero.
	Note: We could actually get out here immediately 
	but wide lines rely on an accurate setup in this case"
	deltaY = 0
		ifTrue:[	error _ 0.			"No error for horizontal edges"
				xInc _ deltaX.		"Encodes width and direction"
				errorAdjUp _ 0]
		ifFalse:["Check if edge is y-major"
				deltaY > widthX "Note: The '>' instead of '>=' could be important here..."
					ifTrue:[	xInc _ 0.
							errorAdjUp _ widthX]
					ifFalse:[	xInc _ (widthX // deltaY) * xDir.
							errorAdjUp _ widthX \\ deltaY]].

	"Store the values"
	self edgeNumLinesOf: line put: deltaY.
	self lineXDirectionOf: line put: xDir.
	"self lineYDirectionOf: line put: yDir." "<-- Already set"
	self lineXIncrementOf: line put: xInc.
	self lineErrorOf: line put: error.
	self lineErrorAdjUpOf: line put: errorAdjUp.
	self lineErrorAdjDownOf: line put: deltaY.

	"And step to the first scan line"
	(startY _ self edgeYValueOf: line) = yValue ifFalse:[
		startY to: yValue-1 do:[:i| self stepToNextLineIn: line at: i].
		"Adjust number of lines remaining"
		self edgeNumLinesOf: line put: deltaY - (yValue - startY).
	].