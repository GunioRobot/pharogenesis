makeNewGameButton
	^ self
		buildButton: SimpleButtonMorph new
		target: self
		label: 'New game' translated
		selector: #newGame