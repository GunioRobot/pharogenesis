paneForWantsFiringWhileDownToggle

	^self inARow: {
		self
			directToggleButtonFor: self 
			getter: #targetRepeatingWhileDown
			setter: #toggleTargetRepeatingWhileDown
			help: 'Turn repeating while mouse is held down on or off' translated.
		self lockedString: ' Mouse-down repeating ' translated.
	}
