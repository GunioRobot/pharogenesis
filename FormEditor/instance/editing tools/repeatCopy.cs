repeatCopy
	"As long as the red button is pressed, copy the source form onto the 
	display screen."

	[sensor redButtonPressed]
		whileTrue: 
			[form
				displayOn: Display
				at: self cursorPoint
				clippingBox: view insetDisplayBox
				rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
				fillColor: color]