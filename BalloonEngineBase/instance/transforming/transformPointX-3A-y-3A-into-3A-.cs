transformPointX: xValue y: yValue into: dstPoint
	"Transform srcPoint into dstPoint by using the currently loaded matrix"
	"Note: This should be rewritten so that inlining works (e.g., removing
	the declarations and adding argument coercions at the appropriate points)"
	| x y transform |
	self inline: true. "Won't help at the moment ;-("
	self var: #dstPoint declareC:'int *dstPoint'.
	self var: #xValue declareC: 'double xValue'.
	self var: #yValue declareC: 'double yValue'.
	self var: #transform declareC:'float *transform'.
	transform _ self edgeTransform.
	x _ ((((transform at: 0) * xValue) +
		((transform at: 1) * yValue) +
		(transform at: 2)) * self aaLevelGet asFloat) asInteger.
	y _ ((((transform at: 3) * xValue) +
		((transform at: 4) * yValue) +
		(transform at: 5)) * self aaLevelGet asFloat) asInteger.
	dstPoint at: 0 put: x.
	dstPoint at: 1 put: y.