board: theBoard

	board _ theBoard.
	4 timesRepeat: [
		self addMorph: (
			RectangleMorph new
				color: color;
				extent: board cellSize;
				borderRaised
		 )
	].
	self positionCellMorphs.