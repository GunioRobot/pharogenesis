stretchFrame: newFrameBlock startingWith: startFrame 
	"Track the outline of a newFrame as long as mouse drags it.
	Maintain max and min constraints throughout the drag"
	| frame newFrame click |
	frame _ startFrame origin extent: ((startFrame extent min: self maximumSize)
											max: self minimumSize).
	Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
	click _ false.
	[click and: [Sensor noButtonPressed]] whileFalse: 
		[Processor yield.
		click _ click | Sensor anyButtonPressed.
		newFrame _ newFrameBlock value: frame.
		newFrame _ newFrame topLeft extent: ((newFrame extent min: self maximumSize)
											max: self minimumSize).
		newFrame = frame ifFalse:
			[Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
			Display border: newFrame width: 2 rule: Form reverse fillColor: Color gray.
			frame _ newFrame]].
	Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
	^ frame