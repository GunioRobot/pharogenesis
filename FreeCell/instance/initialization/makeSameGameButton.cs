makeSameGameButton
	^ self
		buildButton: SimpleButtonMorph new
		target: self
		label: 'Same game' translated
		selector: #sameGame