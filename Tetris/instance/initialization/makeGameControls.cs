makeGameControls
	^ self rowForButtons
		addMorph: (self
				buildButtonTarget: self
				label: 'Quit' translated
				selector: #delete
				help: 'quit' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: 'Pause' translated
				selector: #pause
				help: 'pause' translated);
		
		addMorph: (self
				buildButtonTarget: board
				label: 'New game' translated
				selector: #newGame
				help: 'new game' translated)