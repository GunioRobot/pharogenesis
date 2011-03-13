curve
	"Conic-section specified by three points designated by: first point--press 
	red button second point--release red button third point--click red button. 
	The resultant curve on the display is displayed according to the current 
	form and mode."

	| firstPoint secondPoint thirdPoint curve |
	"sensor noButtonPressed ifTrue: [^self]."
	firstPoint _ self cursorPoint.
	form
		displayOn: Display
		at: firstPoint
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
		fillColor: color.
	secondPoint _ self trackFormUntil: [sensor noButtonPressed].
	form
		displayOn: Display
		at: secondPoint
		clippingBox: view insetDisplayBox
		rule: Form reverse
		fillColor: color.
	thirdPoint _ self trackFormUntil: [sensor redButtonPressed]..
	form
		displayOn: Display
		at: thirdPoint
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
		fillColor: color.
	form
		displayOn: Display
		at: secondPoint
		clippingBox: view insetDisplayBox
		rule: Form reverse
		fillColor: color.
	curve _ Curve new.
	curve firstPoint: firstPoint.
	curve secondPoint: secondPoint.
	curve thirdPoint: thirdPoint.
	curve form: form.
	curve
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
		fillColor: color.
	sensor waitNoButton