paneForActsOnMouseUpToggle

	^self inARow: {
		self
			directToggleButtonFor: self 
			getter: #targetActsOnMouseUp
			setter: #toggleTargetActsOnMouseUp
			help: 'If the button is to act when the mouse goes up' translated.
		self lockedString: ' Mouse-up action' translated.
	}
