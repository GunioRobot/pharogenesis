line
	"Line is specified by two points from the mouse: first point--press red 
	button; second point--release red button. The resultant line is displayed 
	according to the current form and mode."

	| firstPoint endPoint |
	firstPoint _ self cursorPoint.
	endPoint _ self rubberBandFrom: firstPoint until: [sensor noButtonPressed].
	(Line from: firstPoint to: endPoint withForm: form)
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [Form paint]
										ifFalse: [mode])
		fillColor: color