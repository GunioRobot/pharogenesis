adjustWideBezierLeft: bezier width: lineWidth offset: lineOffset endX: endX
	"Adjust the wide bezier curve (dx < 0) to start/end at the right point"
	| lastX lastY |
	self inline: false.
	(self bezierUpdateDataOf: bezier) at: GBUpdateX put: 
		(((self bezierUpdateDataOf: bezier) at: GBUpdateX) - (lineOffset * 256)).
	"Set the lastX/Y value of the second curve lineWidth pixels right/down"
	lastX _ (self wideBezierUpdateDataOf: bezier) at: GBUpdateX.
	(self wideBezierUpdateDataOf: bezier) at: GBUpdateX put: lastX + (lineWidth - lineOffset * 256).
	"Set lineWidth pixels down"
	lastY _ (self wideBezierUpdateDataOf: bezier) at: GBUpdateY.
	(self wideBezierUpdateDataOf: bezier) at: GBUpdateY put: lastY + (lineWidth * 256).
	"Record the last X value"
	self bezierFinalXOf: bezier put: endX - lineOffset.
