stepToNextBezierIn: bezier at: yValue
	"Incrementally step to the next scan line in the given bezier"
	|  xValue |
	self inline: true.
	xValue _ self stepToNextBezierForward: (self bezierUpdateDataOf: bezier) at: yValue.
	self edgeXValueOf: bezier put: xValue.