newRectButtonPressedDo: newRectBlock 
	"Track the outline of a new rectangle until mouse button 
	changes. newFrameBlock produces each new rectangle from the 
	previous. Only tracks while mouse is down."
	| rect newRect buttonNow aHand delay |
	delay _ Delay forMilliseconds: 10.
	buttonNow _ Sensor anyButtonPressed.
	rect _ self.
	Display
		border: rect
		width: 2
		rule: Form reverse
		fillColor: Color gray.
	[buttonNow]
		whileTrue: [delay wait.
			buttonNow _ Sensor anyButtonPressed.
			newRect _ newRectBlock value: rect.
			newRect = rect
				ifFalse: [Display
						border: rect
						width: 2
						rule: Form reverse
						fillColor: Color gray.
					Display
						border: newRect
						width: 2
						rule: Form reverse
						fillColor: Color gray.
					rect _ newRect]].
	Display
		border: rect
		width: 2
		rule: Form reverse
		fillColor: Color gray.
	" pay the price for reading the sensor directly ; get this party started "
	Smalltalk isMorphic
		ifTrue: [aHand _ World activeHand.
			aHand newMouseFocus: nil;
				 showTemporaryCursor: nil;
				 flushEvents].
	Sensor processEvent: Sensor createMouseEvent.
	^ rect