line
	"Line is specified by two points from the mouse: first point--press red 
	button; second point--release red button. The resultant line is displayed 
	according to the current form and mode."

	| firstPoint endPoint drawForm |
	drawForm := form asFormOfDepth: Display depth.
	
	 Display depth > 1 
	  ifTrue:
	    [drawForm mapColor: Color white to: Color transparent; 
	                 mapColor: Color black to: color].
	           
	firstPoint _ self cursorPoint.
	endPoint _ self rubberBandFrom: firstPoint until: [sensor noButtonPressed].
	endPoint isNil ifTrue: [^self].
	Display depth > 1 ifTrue: [self deleteRubberBandFrom: firstPoint to: endPoint.].
	(Line from: firstPoint to: endPoint withForm: drawForm)
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [mode ~= Form erase ifTrue: [Form paint] ifFalse: [mode]]
								ifFalse: [mode])
		fillColor: (Display depth = 1 ifTrue: [color] ifFalse: [nil]).  
		hasUnsavedChanges contents: true.