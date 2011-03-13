stretchFrame: newFrameBlock startingWith: startFrame 
	"Track the outline of a newFrame as long as mouse drags it.
	Maintain max and min constraints throughout the drag"
	| frame newFrame click delay |
	delay := Delay forMilliseconds: 10.
	frame := startFrame origin extent: ((startFrame extent min: self maximumSize)
											max: self minimumSize).
	Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
	click := false.
	[click and: [Sensor noButtonPressed]] whileFalse: 
		[delay wait.
		click := click | Sensor anyButtonPressed.
		newFrame := newFrameBlock value: frame.
		newFrame := newFrame topLeft extent: ((newFrame extent min: self maximumSize)
											max: self minimumSize).
		newFrame = frame ifFalse:
			[Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
			Display border: newFrame width: 2 rule: Form reverse fillColor: Color gray.
			frame := newFrame]].
	Display border: frame width: 2 rule: Form reverse fillColor: Color gray.
	^ frame