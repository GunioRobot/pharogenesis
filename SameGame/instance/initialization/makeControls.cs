makeControls

	| row |
	row _ AlignmentMorph newRow
		color: color;
		borderWidth: 0;
		layoutInset: 3.
	row hResizing: #spaceFill; vResizing: #shrinkWrap; wrapCentering: #center; cellPositioning: #leftCenter; extent: 5@5.
	row addMorph:
		(self
			buildButton: SimpleSwitchMorph new
			target: self
			label: 'Help'
			selector: #help:).
	row addMorph:
		(self
			buildButton: SimpleButtonMorph new
			target: self
			label: 'Quit'
			selector: #delete).
	row addMorph:
		(self
			buildButton: SimpleButtonMorph new
			target: self board
			label: 'Hint'
			selector: #hint).
	row addMorph:
		(self
			buildButton: SimpleButtonMorph new
			target: self
			label: 'New game'
			selector: #newGame).
	selectionDisplay _ LedMorph new
		digits: 2;
		extent: (2*10@15).
	row addMorph: (self wrapPanel: selectionDisplay label: 'Selection:').
	scoreDisplay _ LedMorph new
		digits: 4;
		extent: (4*10@15).
	row addMorph: (self wrapPanel: scoreDisplay label: 'Score:').
	^ row