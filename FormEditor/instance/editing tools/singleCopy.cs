singleCopy 
	"If the red button is clicked, copy the source form onto the display 
	screen."

	form
		displayOn: Display
		at: self cursorPoint
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
		fillColor: color.
	sensor waitNoButton