showScoreDisplay
	^ self rowForButtons hResizing: #shrinkWrap;
		
		addMorph: (self wrapPanel: ((scoreDisplay := LedMorph new) digits: 5;
					 extent: 4 * 10 @ 15) label: 'Score:' translated)