makeMovementControls

	^self rowForButtons
		addMorph:
			(self
				buildButtonTarget: board
				label: '->'
				selector: #moveRight
				help: 'move to the right');
		addMorph:
			(self
				buildButtonTarget: board
				label: ' ) '
				selector: #rotateClockWise
				help: 'rotate clockwise');
		addMorph:
			(self
				buildButtonTarget: board
				label: ' | '
				selector: #dropAllTheWay
				help: 'drop');
		addMorph:
			(self
				buildButtonTarget: board
				label: ' ( '
				selector: #rotateAntiClockWise
				help: 'rotate anticlockwise');
		addMorph:
			(self
				buildButtonTarget: board
				label: '<-'
				selector: #moveLeft
				help: 'move to the left')