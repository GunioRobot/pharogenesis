stepToNextWideBezierIn: bezier at: yValue
	"Incrementally step to the next scan line in the given wide bezier"
	|  yEntry yExit lineWidth lineOffset |
	self inline: false.	"Don't inline this"

	lineWidth _ self wideBezierExtentOf: bezier.
	lineOffset _ self offsetFromWidth: lineWidth.

	yEntry _ (self wideBezierEntryOf: bezier) + 1.
	yExit _ (self wideBezierExitOf: bezier) + 1.
	self wideBezierEntryOf: bezier put: yEntry.
	self wideBezierExitOf: bezier put: yExit.
	yEntry >= lineOffset ifTrue:[self edgeFillsValidate: bezier].
	yExit >= 0 ifTrue:[self edgeFillsInvalidate: bezier].

	"Check if we have to step the upper curve"
	(yExit + lineOffset < 0) ifTrue:[
		self stepToNextBezierForward: (self bezierUpdateDataOf: bezier) at: yValue.
	] ifFalse:[
		"Adjust the last x value to the final x recorded previously"
		(self bezierUpdateDataOf: bezier) at: GBUpdateX put: (self bezierFinalXOf: bezier) * 256.
	].
	"Step the lower curve"
	self stepToNextBezierForward: (self wideBezierUpdateDataOf: bezier) at: yValue.

	self computeFinalWideBezierValues: bezier width: lineWidth.