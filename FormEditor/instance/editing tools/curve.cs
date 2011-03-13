curve
	"Conic-section specified by three points designated by: first point--press 
	red button second point--release red button third point--click red button. 
	The resultant curve on the display is displayed according to the current 
	form and mode."

	| firstPoint secondPoint thirdPoint curve drawForm |
	"sensor noButtonPressed ifTrue: [^self]."
	firstPoint := self cursorPoint.
	secondPoint := self rubberBandFrom: firstPoint until: [sensor noButtonPressed].
	thirdPoint :=  self rubberBandFrom: secondPoint until: [sensor redButtonPressed].
	Display depth > 1
	  ifTrue:
	    [self deleteRubberBandFrom: secondPoint to: thirdPoint.
	     self deleteRubberBandFrom: firstPoint to: secondPoint].
	curve := CurveFitter new.
	curve firstPoint: firstPoint.
	curve secondPoint: secondPoint.
	curve thirdPoint: thirdPoint.
	drawForm := form asFormOfDepth: Display depth.
	Display depth > 1 ifTrue:
	  [drawForm mapColor: Color white to: Color transparent; 
	               mapColor: Color black to: color].

	curve form: drawForm.
	curve
		displayOn: Display
		at: 0 @ 0
		clippingBox: view insetDisplayBox
		rule: (Display depth > 1 ifTrue: [mode ~= Form erase ifTrue: [Form paint] ifFalse: [mode]]
										ifFalse: [mode])
		fillColor: (Display depth = 1 ifTrue: [color] ifFalse: [nil]). 
	sensor waitNoButton.
	hasUnsavedChanges contents: true.