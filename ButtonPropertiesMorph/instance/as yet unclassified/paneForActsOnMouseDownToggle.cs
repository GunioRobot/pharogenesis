paneForActsOnMouseDownToggle

	^self inARow: {
		self
			directToggleButtonFor: self 
			getter: #targetActsOnMouseDown
			setter: #toggleTargetActsOnMouseDown
			help: 'If the button is to act when the mouse goes down' translated.
		self lockedString: ' Mouse-down action' translated.
	}
