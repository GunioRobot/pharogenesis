makeQuitButton
	^ self
		buildButton: SimpleButtonMorph new
		target: self
		label: 'Quit' translated
		selector: #quit