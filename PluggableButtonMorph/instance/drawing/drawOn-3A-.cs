drawOn: aCanvas 

	super drawOn: aCanvas.
	showSelectionFeedback ifTrue: [
		aCanvas frameRectangle: self innerBounds width: 2 color: feedbackColor].
