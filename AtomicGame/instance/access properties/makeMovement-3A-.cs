makeMovement: aDirection 
	selected canBeProgramed
		ifTrue: ["Increase the movements counter"
			mapMoves _ mapMoves + 1.
			self showPointsInfo.
			"Moves the piece"
			selected
				startMovement: (self getNextPosition: aDirection)]