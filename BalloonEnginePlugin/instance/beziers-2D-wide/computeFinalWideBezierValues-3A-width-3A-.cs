computeFinalWideBezierValues: bezier width: lineWidth
	"Get both values from the two boundaries of the given bezier 
	and compute the actual position/width of the line"
	| leftX rightX temp |
	leftX _ ((self bezierUpdateDataOf: bezier) at: GBUpdateX) // 256.
	rightX _ ((self wideBezierUpdateDataOf: bezier) at: GBUpdateX) // 256.
	leftX > rightX ifTrue:[temp _ leftX. leftX _ rightX. rightX _ temp].
	self edgeXValueOf: bezier put: leftX.
	(rightX - leftX) > lineWidth ifTrue:[
		self wideBezierWidthOf: bezier put: (rightX - leftX).
	] ifFalse:[
		self wideBezierWidthOf: bezier put: lineWidth.
	].