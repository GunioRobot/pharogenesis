stepToFirst
	|  startX endX startY endY deltaY fwX1 fwX2 fwY1 fwY2 
	steps scaledStepSize squaredStepSize |
	(end y) >= (start y) ifTrue:[
		startX _ start x.	endX _ end x.
		startY _ start y.	endY _ end y.
	] ifFalse:[
		startX _ end x.	endX _ start x.
		startY _ end y.	endY _ start y.
	].

	deltaY _ endY - startY.

	"Quickly check if the line is visible at all"
	(deltaY = 0) ifTrue:[^self].

	fwX1 _ (startX + endX - (2 * via x)) asFloat.
	fwX2 _ (via x - startX * 2) asFloat.
	fwY1 _ (startY + endY - (2 * via y)) asFloat.
	fwY2 _ ((via y - startY) * 2) asFloat.
	steps _ deltaY asInteger * 2.
	scaledStepSize _ 1.0 / steps asFloat.
	squaredStepSize _ scaledStepSize * scaledStepSize.
	fwDx _ fwX2 * scaledStepSize.
	fwDDx _ 2.0 * fwX1 * squaredStepSize.
	fwDy _ fwY2 * scaledStepSize.
	fwDDy _ 2.0 * fwY1 * squaredStepSize.
	fwDx _ fwDx + (fwDDx * 0.5).
	fwDy _ fwDy + (fwDDy * 0.5).

	lastX _ startX asFloat.
	lastY _ startY asFloat.
