stepToFirstBezierIn: bezier at: yValue
	"Initialize the bezier at yValue.
	TODO: Check if reducing maxSteps from 2*deltaY to deltaY 
		brings a *significant* performance improvement.
		In theory this should make for double step performance
		but will cost in quality. Might be that the AA stuff will
		compensate for this - but I'm not really sure."
	| updateData deltaY maxSteps scaledStepSize squaredStepSize 
	startX startY viaX viaY endX endY 
	fwX1 fwX2 fwY1 fwY2 
	fwDx fwDDx fwDy fwDDy |
	self inline: false. "Too many temps for useful inlining"
	self var: #updateData declareC:'int *updateData'.


	"Do a quick check if there is anything at all to do"
	((self isWide: bezier) not and:[yValue >= (self bezierEndYOf: bezier)])
		ifTrue:[^self edgeNumLinesOf: bezier put: 0].

	"Now really initialize bezier"
	startX _ self edgeXValueOf: bezier.
	startY _ self edgeYValueOf: bezier.
	viaX _ self bezierViaXOf: bezier.
	viaY _ self bezierViaYOf: bezier.
	endX _ self bezierEndXOf: bezier.
	endY _ self bezierEndYOf: bezier.
	deltaY _ endY - startY.

	"Initialize integer forward differencing"
	fwX1 _ (viaX - startX) * 2.
	fwX2 _ startX + endX - (viaX * 2).
	fwY1 _ (viaY - startY) * 2.
	fwY2 _ startY + endY - (viaY * 2).
	maxSteps _ deltaY * 2.
	maxSteps < 2 ifTrue:[maxSteps _ 2].
	scaledStepSize _ 16r1000000 // maxSteps.
	squaredStepSize _ self absoluteSquared8Dot24: scaledStepSize.
	fwDx _ fwX1 * scaledStepSize.
	fwDDx _ fwX2 * squaredStepSize * 2.
	fwDx _ fwDx + (fwDDx // 2).
	fwDy _ fwY1 * scaledStepSize.
	fwDDy _ fwY2 * squaredStepSize * 2.
	fwDy _ fwDy + (fwDDy // 2).

	"Store the values"
	self edgeNumLinesOf: bezier put: deltaY.

	updateData _ self bezierUpdateDataOf: bezier.
	updateData at: GBUpdateX put: (startX * 256).
	updateData at: GBUpdateY put: (startY * 256).
	updateData at: GBUpdateDX put: fwDx.
	updateData at: GBUpdateDY put: fwDy.
	updateData at: GBUpdateDDX put: fwDDx.
	updateData at: GBUpdateDDY put: fwDDy.

	"And step to the first scan line"
	(startY _ self edgeYValueOf: bezier) = yValue ifFalse:[
		self stepToNextBezierIn: bezier at: yValue.
		"Adjust number of lines remaining"
		self edgeNumLinesOf: bezier put: deltaY - (yValue - startY).
	].