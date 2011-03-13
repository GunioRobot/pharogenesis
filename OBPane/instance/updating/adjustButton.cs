adjustButton
	| inner |
	self hasButton ifTrue: 
		[inner _ self innerBounds.
		button bounds: (inner withTop: inner bottom - self buttonHeight)]