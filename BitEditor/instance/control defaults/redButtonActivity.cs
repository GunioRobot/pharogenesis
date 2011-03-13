redButtonActivity
	| formPoint displayPoint |
	model depth = 1 ifTrue:
		["If this is just a black&white form, then set the color to be
		the opposite of what it was where the mouse was clicked"
		formPoint := (view inverseDisplayTransform: sensor cursorPoint - (scale//2)) rounded.
		color := 1-(view workingForm pixelValueAt: formPoint).
		squareForm fillColor: (color=1 ifTrue: [Color black] ifFalse: [Color white])].
	[sensor redButtonPressed]
	  whileTrue: 
		[formPoint := (view inverseDisplayTransform: sensor cursorPoint - (scale//2)) rounded.
		displayPoint := view displayTransform: formPoint.
		squareForm 
			displayOn: Display
			at: displayPoint 
			clippingBox: view insetDisplayBox 
			rule: Form over
			fillColor: nil.
		view changeValueAt: formPoint put: color]