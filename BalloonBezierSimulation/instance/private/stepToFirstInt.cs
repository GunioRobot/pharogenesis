stepToFirstInt
	"Scaled integer version of forward differencing"
	|  startX endX startY endY deltaY fwX1 fwX2 fwY1 fwY2 
	 scaledStepSize squaredStepSize |
	self halt.
	(end y) >= (start y) ifTrue:[
		startX _ start x.	endX _ end x.
		startY _ start y.	endY _ end y.
	] ifFalse:[
		startX _ end x.	endX _ start x.
		startY _ end y.	endY _ start y.
	].

	deltaY _ endY - startY.

	"Quickly check if the line is visible at all"
	(deltaY = 0) ifTrue:[^nil].

	fwX1 _ (startX + endX - (2 * via x)).
	fwX2 _ (via x - startX * 2).
	fwY1 _ (startY + endY - (2 * via y)).
	fwY2 _ ((via y - startY) * 2).
	maxSteps _ deltaY asInteger * 2.
	scaledStepSize _ 16r1000000 // maxSteps.
	"@@: Okay, we need some fancy 64bit multiplication here"
	squaredStepSize _ (scaledStepSize * scaledStepSize) bitShift: -24.
	fwDx _ fwX2 * scaledStepSize.
	fwDDx _ 2 * fwX1 * squaredStepSize.
	fwDy _ fwY2 * scaledStepSize.
	fwDDy _ 2 * fwY1 * squaredStepSize.
	fwDx _ fwDx + (fwDDx // 2).
	fwDy _ fwDy + (fwDDy // 2).

	self validateIntegerRange.

	lastX _ startX * 256.
	lastY _ startY * 256.
