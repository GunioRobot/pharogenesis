makeGameControls

	^self rowForButtons
		addMorph:
			(self
				buildButtonTarget: self
				label: 'Quit'
				selector: #delete
				help: 'quit');
		addMorph:
			(self
				buildButtonTarget: board
				label: 'Pause'
				selector: #pause
				help: 'pause');
		addMorph:
			(self
				buildButtonTarget: board
				label: 'New game'
				selector: #newGame
				help: 'new game')