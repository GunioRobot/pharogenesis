makeMovementControls
	^ self rowForButtons
		addMorph: (self
				buildButtonTarget: board
				label: '->'
				selector: #moveRight
				help: 'move to the right' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: ' ) '
				selector: #rotateClockWise
				help: 'rotate clockwise' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: ' | '
				selector: #dropAllTheWay
				help: 'drop' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: ' ( '
				selector: #rotateAntiClockWise
				help: 'rotate anticlockwise' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: '<-'
				selector: #moveLeft
				help: 'move to the left' translated)