makeControls
	| row |
	row := AlignmentMorph newRow color: color;
				 borderWidth: 2;
				 layoutInset: 3.
	row borderColor: #inset.
	row hResizing: #spaceFill;
		 vResizing: #shrinkWrap;
		 wrapCentering: #center;
		 cellPositioning: #leftCenter;
		 extent: 5 @ 5.
	row
		addMorph: (self
				buildButton: SimpleSwitchMorph new
				target: self
				label: '  Help  ' translated
				selector: #help:).
	row
		addMorph: (self
				buildButton: SimpleButtonMorph new
				target: self
				label: '  Quit  ' translated
				selector: #delete).
	"row 
	addMorph: (self 
	buildButton: SimpleButtonMorph new 
	target: self 
	label: ' Hint '  translated
	selector: #hint)."
	row
		addMorph: (self
				buildButton: SimpleButtonMorph new
				target: self
				label: '  New game  ' translated
				selector: #newGame).
	minesDisplay := LedMorph new digits: 2;
				 extent: 2 * 10 @ 15.
	row
		addMorph: (self wrapPanel: minesDisplay label: 'Mines:' translated).
	timeDisplay := LedTimerMorph new digits: 3;
				 extent: 3 * 10 @ 15.
	row
		addMorph: (self wrapPanel: timeDisplay label: 'Time:' translated).
	^ row