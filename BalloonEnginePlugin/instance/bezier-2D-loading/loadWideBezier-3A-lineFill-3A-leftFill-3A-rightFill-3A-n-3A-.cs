loadWideBezier: lineWidth lineFill: lineFill leftFill: leftFill rightFill: rightFill n: nSegments
	"Load the (possibly wide) bezier from the segments currently on the bezier stack."
	| index bezier wide offset |
	self inline: false.
	(lineWidth = 0 or:[lineFill = 0])
		ifTrue:[wide _ false.
				offset _ 0]
		ifFalse:[wide _ true.
				offset _ self offsetFromWidth: lineWidth].
	index _ nSegments * 6.
	[index > 0] whileTrue:[
		wide 
			ifTrue:[bezier _ self allocateWideBezier]
			ifFalse:[bezier _ self allocateBezier].
		engineStopped ifTrue:[^0].
		self loadBezier: bezier 
			segment: index 
			leftFill: leftFill 
			rightFill: rightFill 
			offset: offset.
		wide ifTrue:[
			self wideBezierFillOf: bezier put: lineFill.
			self wideBezierWidthOf: bezier put: lineWidth.
			self wideBezierExtentOf: bezier put: lineWidth.
		].
		index _ index - 6.
	].
	self wbStackClear.