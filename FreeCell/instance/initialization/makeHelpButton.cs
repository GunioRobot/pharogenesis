makeHelpButton
	^ self
		buildButton: SimpleButtonMorph new
		target: self
		label: 'Help' translated
		selector: #help