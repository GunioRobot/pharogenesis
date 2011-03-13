redButtonActivity
	| absoluteScreenPoint formPoint displayPoint |
	[sensor redButtonPressed]
	  whileTrue: 
		[absoluteScreenPoint _ sensor cursorPoint.	
		formPoint _ (view inverseDisplayTransform: absoluteScreenPoint - (scale//2)) rounded.
		displayPoint _ view displayTransform: formPoint.
		squareForm 
			displayOn: Display
			at: displayPoint 
			clippingBox: view insetDisplayBox 
			rule: Form over
			fillColor: nil.
		view changeValueAt: formPoint put: color]