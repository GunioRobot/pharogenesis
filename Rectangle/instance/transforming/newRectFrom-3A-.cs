newRectFrom: newRectBlock
	"Track the outline of a new rectangle until mouse button changes.
	newFrameBlock produces each new rectangle from the previous"
	| rect newRect buttonStart buttonNow |
	buttonStart _ buttonNow _ Sensor anyButtonPressed.
	rect _ self.
	Display border: rect width: 2 rule: Form reverse fillColor: Color gray.
	[buttonNow == buttonStart] whileTrue: 
		[Processor yield.
		buttonNow _ Sensor anyButtonPressed.
		newRect _ newRectBlock value: rect.
		newRect = rect ifFalse:
			[Display border: rect width: 2 rule: Form reverse fillColor: Color gray.
			Display border: newRect width: 2 rule: Form reverse fillColor: Color gray.
			rect _ newRect]].
	Display border: rect width: 2 rule: Form reverse fillColor: Color gray.
	^ rect